using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Query;
using SL.Person.Registration.Application.Query.Handler;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;
using SL.Person.Registration.UnitTests.MoqUnitTest;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query.Handler
{
    public class FindPersonByNameQueryHandlerTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[] {
                new FindPersonByNameQuery(null),
                null,
                null,
                false,
                new List<string> { ResourceMessagesValidation.FindPersonByNameQueryValidation_RequestInvalid },
                ErrorType.InvalidParameters
            },
            new object[] {
                new FindPersonByNameQuery(string.Empty),
                null,
                null,
                false,
                new List<string> { ResourceMessagesValidation.FindPersonByNameQueryValidation_RequestInvalid },
                ErrorType.InvalidParameters
            },
             new object[] {
                new FindPersonByNameQuery(" "),
                null,
                null,
                false,
                new List<string> { ResourceMessagesValidation.FindPersonByNameQueryValidation_RequestInvalid },
                ErrorType.InvalidParameters
            },
            new object[]
            {
                new FindPersonByNameQuery("teste"),
                null,
                null,
                false,
                new List<string>() { "Pessoa não encontrada." },
                ErrorType.NotFoundData
            },
            new object[]
            {
                new FindPersonByNameQuery("teste"),
                null,
                new List<PersonRegistration>(),
                false,
                new List<string>() { "Pessoa não encontrada." },
                ErrorType.NotFoundData
            },
            new object[]
            {
                new FindPersonByNameQuery("teste"),
                Builder<FindPersonResult>.CreateListOfSize(1).Build(),
                GetPersonRegistration(),
                true,
                new List<string>(),
                (ErrorType)0
            }
        };

        public static IEnumerable<PersonRegistration> GetPersonRegistration()
        {
            var person = Builder<PersonRegistration>.CreateListOfSize(1).Build();
            foreach (var item in person)
            {
                item.AddAdress(Builder<Address>.CreateNew().Build());
                item.AddContact(Builder<Contact>.CreateNew().Build());
                yield return item;
            }
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async Task Should_execute_handler(FindPersonByNameQuery query, IEnumerable<FindPersonResult> result,
            IEnumerable<PersonRegistration> registration, bool isSucess, List<string> errors, ErrorType errorType)
        {
            //arrange
            var moqRepository = MockInformatioRegistrationRepository.GetMockRepository(registration?.FirstOrDefault());

            //act
            var resultHandler = new FindPersonByNameQueryHandler(moqRepository.Object);
            var handler = await resultHandler.Handle(query, default);

            //assert
            handler.Data.Should().BeEquivalentTo(result);
            handler.IsSuccess.Should().Be(isSucess);
            handler.Errors.Should().BeEquivalentTo(errors);
            handler.ErrorType.Should().Be(errorType);
        }
    }
}
