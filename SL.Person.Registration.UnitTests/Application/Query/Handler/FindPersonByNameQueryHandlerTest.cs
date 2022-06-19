using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Application.Query;
using SL.Person.Registration.Application.Query.Handler;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Results.Base;
using SL.Person.Registration.Domain.Results.Enums;
using SL.Person.Registration.UnitTests.MoqUnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query.Handler
{
    public class FindPersonByNameQueryHandlerTest
    {
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

        [Fact]
        public async Task Should_execute_handler()
        {
            //arrange
            var query = new FindPeopleQuery("teste");
            var registration = GetPersonRegistration();
            var isSucess = true;
            var errors = new List<string>();
            var errorType = (ErrorType)0;

            var moqRepository = MockPersonRegistrationRepository.GetMockRepository(registration?.FirstOrDefault());

            //act
            var resultHandler = new FindPeopleQueryHandler(moqRepository.Object);
            var handler = await resultHandler.Handle(query, default);

            //assert
            handler.IsSuccess.Should().Be(isSucess);
            handler.Errors.Should().BeEquivalentTo(errors);
            handler.ErrorType.Should().Be(errorType);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public async Task Should_execute_handler_invalid_request(string name)
        {
            //arrange
            var queryHandler = new FindPeopleQueryHandler(null);

            //act
            Func<Task<ResultBase>> action = async () => await queryHandler.Handle(new FindPeopleQuery(name), default);

            //assert
            await action.Should().ThrowAsync<ApplicationRequestException>();
        }

        [Fact]
        public async Task Should_execute_handler_person_not_found()
        {
            //arrange
            var moq = MockPersonRegistrationRepository.GetMockRepository(null);
            var queryHandler = new FindPeopleQueryHandler(moq.Object);

            //act
            Func<Task<ResultBase>> action = async () => await queryHandler.Handle(new FindPeopleQuery("name"), default);

            //assert
            await action.Should().ThrowAsync<ApplicationRequestException>();
        }
    }
}
