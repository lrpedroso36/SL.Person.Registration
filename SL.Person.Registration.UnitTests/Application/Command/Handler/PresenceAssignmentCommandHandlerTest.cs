using FluentAssertions;
using MediatR;
using Moq;
using SL.Person.Registration.Application.Command.PresenceAssignment;
using SL.Person.Registration.Application.Commons.Exceptions;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.UnitTests.MoqUnitTest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Handler;

public class PresenceAssignmentCommandHandlerTest
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    [InlineData("asdasdasd")]
    public async void Should_execute_handler_request_invalid(string id)
    {
        //arrange
        var command = new PresenceAssignmentCommand(id);
        var commandHandler = new PresenceAssignmentCommandHandler(null);

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

        var command = new PresenceAssignmentCommand(Guid.NewGuid().ToString());
        var commandHandler = new PresenceAssignmentCommandHandler(moqRepository.Object);

        //act
        Func<Task<Unit>> action = async () => await commandHandler.Handle(command, default);

        //assert
        await action.Should().ThrowAsync<ApplicationRequestException>();
    }

    [Fact]
    public async void Should_execute_handler_date_presence_done()
    {
        //arrange
        var person = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType> { PersonType.Tarefeiro() }, "nome", 123456789);
        person.SetPresenceAssignment(DateTime.Now, true);

        var moqRepository = MockPersonRegistrationRepository.GetMockRepository(person);

        var command = new PresenceAssignmentCommand(Guid.NewGuid().ToString());
        var commandHandler = new PresenceAssignmentCommandHandler(moqRepository.Object);

        //act
        Func<Task<Unit>> action = async () => await commandHandler.Handle(command, default);

        //assert
        await action.Should().ThrowAsync<ApplicationRequestException>();
    }

    [Fact]
    public async void Should_execute_handler()
    {
        //arrage
        var personNotLaborer = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType> { PersonType.Tarefeiro() }, "nome", 123456789);
        var moqRepository = MockPersonRegistrationRepository.GetMockRepository(personNotLaborer);

        var command = new PresenceAssignmentCommand(Guid.NewGuid().ToString());
        var commandHandler = new PresenceAssignmentCommandHandler(moqRepository.Object);

        //act
        var result = await commandHandler.Handle(command, default);

        //assert
        moqRepository.Verify(x => x.GetByIdAsync(It.IsAny<string>(), default), Times.Once);
        moqRepository.Verify(x => x.UpdateAsync(It.IsAny<PersonRegistration>(), default), Times.Once);

        result.Should().Be(Unit.Value);
    }
}
