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
    public class FindPersonByContactNumberQueryHandlerTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[]
            {
                new FindPersonByContactNumberQuery(1,1),
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
        public async Task Should_execute_handler(FindPersonByContactNumberQuery query, FindPersonResult result,
            PersonRegistration registration, bool isSucess, List<string> errors, ErrorType errorType)
        {
            //arange
            var moqRepository = MockPersonRegistrationRepository.GetMockRepository(registration);

            //act
            var resultHandler = new FindPersonByContactNumberQueryHandler(moqRepository.Object);
            var handler = await resultHandler.Handle(query, default);

            //assert
            handler.IsSuccess.Should().Be(isSucess);
            handler.Errors.Should().BeEquivalentTo(errors);
            handler.ErrorType.Should().Be(errorType);
        }
    }
}
