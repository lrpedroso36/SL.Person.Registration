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
using System.Threading.Tasks;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query.Handler
{
    public class FindPersonByDocumentQueryHandlerTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[] {
                new FindPersonByDocumentQuery(0),
                null,
                null,
                false,
                new List<string>() { ResourceMessagesValidation.FindPersonByDocumentQueryValidation_RequestInvalid },
                ErrorType.InvalidParameters
            },
             new object[] {
                new FindPersonByDocumentQuery(1),
                null,
                null,
                false,
                new List<string>() { ResourceMessagesValidation.PersonRegistration_InstanceInvalid },
                ErrorType.NotFoundData
            },
            new object[]
            {
                new FindPersonByDocumentQuery(123456789),
                Builder<FindPersonResult>.CreateNew().Build(),
                GetPersonRegistration(),
                true,
                new List<string>(),
                (ErrorType)0
            }
        };

        public static PersonRegistration GetPersonRegistration()
        {
            var person = Builder<PersonRegistration>.CreateNew().Build();
            person.AddAdress(Builder<Address>.CreateNew().Build());
            person.AddContact(Builder<Contact>.CreateNew().Build());
            return person;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async Task Should_execute_handler(FindPersonByDocumentQuery query, FindPersonResult result,
            PersonRegistration registration, bool isSucess, List<string> errors, ErrorType errorType)
        {
            //arrange
            var moqRepository = MockInformatioRegistrationRepository.GetMockRepository(registration);

            //act
            var resultHandler = new FindPersonByDocumentQueryHandler(moqRepository.Object);
            var handler = await resultHandler.Handle(query, default);

            //assert
            handler.Data.Should().BeEquivalentTo(result);
            handler.IsSuccess.Should().Be(isSucess);
            handler.Errors.Should().BeEquivalentTo(errors);
            handler.ErrorType.Should().Be(errorType);
        }
    }
}
