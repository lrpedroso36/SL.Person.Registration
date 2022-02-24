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
using System.Threading.Tasks;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query.Handler
{
    public class FindPersonByDocumentQueryHandlerTest
    {
        public static PersonRegistration GetPersonRegistration()
        {
            var person = Builder<PersonRegistration>.CreateNew().Build();
            person.AddAdress(Builder<Address>.CreateNew().Build());
            person.AddContact(Builder<Contact>.CreateNew().Build());
            return person;
        }

        [Fact]
        public async Task Should_execute_handler()
        {
            //arrange
            var query = new FindPersonByDocumentQuery(123456789);
            var registration = GetPersonRegistration();
            var isSucess = true;
            var errors = new List<string>();
            var errorType = (ErrorType)0;

            var moqRepository = MockPersonRegistrationRepository.GetMockRepository(registration);

            //act
            var resultHandler = new FindPersonByDocumentQueryHandler(moqRepository.Object);
            var handler = await resultHandler.Handle(query, default);

            //assert
            handler.IsSuccess.Should().Be(isSucess);
            handler.Errors.Should().BeEquivalentTo(errors);
            handler.ErrorType.Should().Be(errorType);
        }

        [Fact]
        public async Task Should_execute_handler_invalid_request()
        {
            //arrange
            var queryHandler = new FindPersonByDocumentQueryHandler(null);

            //act
            Func<Task<ResultBase>> action = async () => await queryHandler.Handle(new FindPersonByDocumentQuery(0), default);

            //assert
            await action.Should().ThrowAsync<ApplicationRequestException>();
        }

        [Fact]
        public async Task Should_execute_handler_person_not_found()
        {
            //arrange
            var moq = MockPersonRegistrationRepository.GetMockRepository(null);
            var queryHandler = new FindPersonByDocumentQueryHandler(moq.Object);

            //act
            Func<Task<ResultBase>> action = async () => await queryHandler.Handle(new FindPersonByDocumentQuery(1), default);

            //assert
            await action.Should().ThrowAsync<ApplicationRequestException>();
        }
    }
}
