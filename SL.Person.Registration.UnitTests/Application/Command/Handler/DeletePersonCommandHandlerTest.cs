using FluentAssertions;
using MediatR;
using Moq;
using SL.Person.Registration.Application.Command.DeletePerson;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.UnitTests.MoqUnitTest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Handler
{
    public class DeletePersonCommandHandlerTest
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("asdasdasd")]
        public async void Should_execute_handler_request_invalid(string id)
        {
            //arrange
            var command = new DeletePersonCommand(id);
            var commandHandler = new DeletePersonCommandHandler(null);

            //act
            Func<Task<Unit>> action = async () => await commandHandler.Handle(command, default);

            //assert
            await action.Should().ThrowAsync<ApplicationRequestException>();
        }

        [Fact]
        public async void Should_execute_handler_person_not_found()
        {
            //arrage
            var moqRepository = MockPersonRegistrationRepository.GetMockRepository(null);

            var command = new DeletePersonCommand(Guid.NewGuid().ToString());
            var commandHandler = new DeletePersonCommandHandler(moqRepository.Object);

            //act
            Func<Task<Unit>> action = async () => await commandHandler.Handle(command, default);

            //assert
            await action.Should().ThrowAsync<ApplicationRequestException>();
        }

        [Fact]
        public async void Should_execute_handler()
        {
            //arrage
            var personNotLaborer = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType> { PersonType.Tarefeiro }, "nome", 123456789);
            var moqRepository = MockPersonRegistrationRepository.GetMockRepository(personNotLaborer);

            var command = new DeletePersonCommand(Guid.NewGuid().ToString());
            var commandHandler = new DeletePersonCommandHandler(moqRepository.Object);

            //act
            var result = await commandHandler.Handle(command, default);

            //assert
            moqRepository.Verify(x => x.GetById(It.IsAny<string>()), Times.Once);
            moqRepository.Verify(x => x.Update(It.IsAny<PersonRegistration>()), Times.Once);

            result.Should().Be(Unit.Value);
        }
    }
}
