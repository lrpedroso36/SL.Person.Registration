using FizzWare.NBuilder;
using FluentAssertions;
using MediatR;
using Moq;
using SL.Person.Registration.Application.Command.InsertWorkSchedules;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.UnitTests.MoqUnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Handler
{
    public class InsertWorkSchedulesCommandHandlerTest
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("asdasdasd")]
        public async Task Should_id_validate_request_when_execute_handler(string id)
        {
            //arrange
            var request = new InsertWorkSchedulesCommand(id, Builder<InsertWorkSchedulesCommand.WorkScheduleCommand>.CreateListOfSize(1).Build().ToList());
            //act
            var commandHandler = new InsertWorkSchedulesCommandHandler(null);
            Func<Task<Unit>> action = async () => await commandHandler.Handle(request, default);

            //assert
            await action.Should().ThrowAsync<ApplicationRequestException>();
        }

        [Fact]
        public async Task Should_works_validate_request_when_execute_handler()
        {
            //arrange
            var id = Guid.NewGuid().ToString();
            var works = new List<InsertWorkSchedulesCommand.WorkScheduleCommand>();
            var request = new InsertWorkSchedulesCommand(id, works);
            //act
            var commandHandler = new InsertWorkSchedulesCommandHandler(null);
            Func<Task<Unit>> action = async () => await commandHandler.Handle(request, default);

            //assert
            await action.Should().ThrowAsync<ApplicationRequestException>();
        }

        [Fact]
        public async Task Shold_validate_person_not_found()
        {
            //arrange
            var id = Guid.NewGuid().ToString();
            var works = Builder<InsertWorkSchedulesCommand.WorkScheduleCommand>.CreateListOfSize(1).Build().ToList();

            PersonRegistration person = null;

            var respository = MockPersonRegistrationRepository.GetMockRepository(person);
            var command = new InsertWorkSchedulesCommand(id, works);

            var commandHandler = new InsertWorkSchedulesCommandHandler(respository.Object);

            //act
            Func<Task<Unit>> action = async () => await commandHandler.Handle(command, default);

            //assert
            await action.Should().ThrowAsync<ApplicationRequestException>();
        }

        [Fact]
        public async Task Should_execute_handler()
        {
            //arrage
            var id = Guid.NewGuid();
            var works = Builder<InsertWorkSchedulesCommand.WorkScheduleCommand>.CreateListOfSize(1).Build().ToList();
            var person = PersonRegistration.CreateInstanceSimple(id, new List<PersonType>() { PersonType.Assistido }, "nome", 123456789);

            var respository = MockPersonRegistrationRepository.GetMockRepository(person);
            var command = new InsertWorkSchedulesCommand(id.ToString(), works);

            var commandHandler = new InsertWorkSchedulesCommandHandler(respository.Object);

            //act
            await commandHandler.Handle(command, default);

            //assert
            respository.Verify(x => x.GetById(It.IsAny<string>()), Times.Once());
            respository.Verify(x => x.Update(It.IsAny<PersonRegistration>()), Times.Once);
        }
    }
}
