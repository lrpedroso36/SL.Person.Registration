using FluentAssertions;
using MediatR;
using Moq;
using SL.Person.Registration.Application.Command.Precence;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Handler
{
    public class PrecenceCommandHandlerTest
    {
        [Fact]
        public async Task Should_execute_handler_request_validate()
        {
            //arrange
            var precenceCommand = new PrecenceCommand(Guid.NewGuid().ToString());
            var resultExpected = Unit.Value;
            var personWatched = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido }, "nome", 1234567890);

            var moq = new Mock<IPersonRegistrationRepository>();
            moq.Setup(x => x.GetById(It.IsAny<string>())).Returns(personWatched);

            //act
            var commandHandler = new PrecenceCommandHandler(moq.Object);
            var result = await commandHandler.Handle(precenceCommand, default);

            //assert
            result.Should().BeEquivalentTo(resultExpected);

            moq.Verify(x => x.GetById(It.IsAny<string>()), Times.Once);
            moq.Verify(x => x.Update(It.IsAny<PersonRegistration>()), Times.Once);

        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("asdasdasd")]
        public async Task Should_execute_handler_invalid_request(string id)
        {
            //arrange
            //act
            var commandHandler = new PrecenceCommandHandler(null);
            Func<Task<Unit>> action = async () => await commandHandler.Handle(new PrecenceCommand(id), default);

            //assert
            await action.Should().ThrowAsync<ApplicationRequestException>();
        }

        [Fact]
        public async Task Should_execute_handler_not_found_person_interviewed()
        {
            //arrange
            PersonRegistration personInterviewed = null;

            var moq = new Mock<IPersonRegistrationRepository>();
            moq.Setup(x => x.GetById(It.IsAny<string>())).Returns(personInterviewed);

            //act
            var commandHandler = new PrecenceCommandHandler(moq.Object);
            Func<Task<Unit>> action = async () => await commandHandler.Handle(new PrecenceCommand(Guid.NewGuid().ToString()), default);

            //assert
            await action.Should().ThrowAsync<ApplicationRequestException>();
        }
    }
}
