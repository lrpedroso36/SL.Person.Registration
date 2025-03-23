using FizzWare.NBuilder;
using FluentAssertions;
using MediatR;
using Moq;
using SL.Person.Registration.Application.Command.Person.Insert;
using SL.Person.Registration.Application.Commons.Exceptions;
using SL.Person.Registration.Application.Commons.Requests;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.UnitTests.MoqUnitTest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Handler
{
    public class InsertPersonCommandHandlerTest
    {
        [Fact]
        public async Task Should_execute_handler()
        {
            //arrange
            var command = new InsertPersonCommand(Builder<PersonRequest>.CreateNew().Build());
            var atMostInsert = 1;

            var mockRepository = MockPersonRegistrationRepository.GetMockRepository(null);

            //act
            var commandHandler = new InsertPersonCommandHandler(mockRepository.Object);
            var result = await commandHandler.Handle(command, default);

            //assert
            mockRepository.Verify(x => x.InsertAsync(It.IsAny<PersonRegistration>(), default), Times.AtMost(atMostInsert));
            mockRepository.Verify(x => x.GetByDocumentASync(It.IsAny<long>(), default), Times.Once);
        }

        [Fact]
        public async Task Should_execute_handler_invalid_found_person()
        {
            //arrange
            var person = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType>() { PersonType.Assistido() }, "nome", 123456789);
            var mockRepository = MockPersonRegistrationRepository.GetMockRepository(person);

            //act
            var commandHandler = new InsertPersonCommandHandler(mockRepository.Object);
            Func<Task<Unit>> action = async () => await commandHandler.Handle(new InsertPersonCommand(new PersonRequest() { DocumentNumber = 123456 }), default);

            //assert
            await action.Should().ThrowAsync<ApplicationRequestException>();
        }

        public static List<object[]> DataInvalid = new List<object[]>()
        {
            new object[] { new InsertPersonCommand(null) },
            new object[] { new InsertPersonCommand(new PersonRequest() { DocumentNumber = 0}) }
        };

        [Theory]
        [MemberData(nameof(DataInvalid))]
        public async Task Should_execute_handler_invalid_request(InsertPersonCommand command)
        {
            //arrange
            //act
            var commandHandler = new InsertPersonCommandHandler(null);
            Func<Task<Unit>> action = async () => await commandHandler.Handle(command, default);

            //assert
            await action.Should().ThrowAsync<ApplicationRequestException>();
        }
    }
}
