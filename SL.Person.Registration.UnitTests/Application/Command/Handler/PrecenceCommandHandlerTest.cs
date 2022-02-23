using FizzWare.NBuilder;
using FluentAssertions;
using MediatR;
using Moq;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Command.Handler;
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
        public static List<object[]> Data = new List<object[]>
        {
            new object[] { new PrecenceCommand(1,1),
                           Unit.Value,
                           PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido }, "nome" ,1234567890),
                           Builder<PersonRegistration>.CreateNew().Build()
            }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public async Task Should_execute_handler_request_validate(PrecenceCommand precenceCommand, Unit resultExpected,
            PersonRegistration personWatched, PersonRegistration personLaborer)
        {
            //arrange
            var moq = new Mock<IPersonRegistrationRepository>();
            moq.Setup(x => x.GetByDocument(It.IsAny<long>())).Returns(personLaborer);
            moq.Setup(x => x.GetByDocument(It.IsAny<long>(), It.IsAny<PersonType>())).Returns(personWatched);

            //act
            var commandHandler = new PrecenceCommandHandler(moq.Object);
            var result = await commandHandler.Handle(precenceCommand, default);

            //assert
            result.Should().BeEquivalentTo(resultExpected);
        }

        public static List<object[]> DataInvalid = new List<object[]>()
        {
            new object[] { new PrecenceCommand(0, 1234556) },
            new object[] { new PrecenceCommand(123456,0)},
        };

        [Theory]
        [MemberData(nameof(DataInvalid))]
        public async Task Should_execute_handler_invalid_request(PrecenceCommand command)
        {
            //arrange
            //act
            var commandHandler = new PrecenceCommandHandler(null);
            Func<Task<Unit>> action = async () => await commandHandler.Handle(command, default);

            //assert
            await action.Should().ThrowAsync<ApplicationRequestException>();
        }

        [Fact]
        public async Task Should_execute_handler_not_found_person_interviewed()
        {
            //arrange
            var personInterviewed = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType>() { PersonType.Tarefeiro }, "nome", 123456789);
            var moq = new Mock<IPersonRegistrationRepository>();
            moq.Setup(x => x.GetByDocument(It.IsAny<long>(), It.IsAny<PersonType>())).Returns(personInterviewed);

            //act
            var commandHandler = new PrecenceCommandHandler(moq.Object);
            Func<Task<Unit>> action = async () => await commandHandler.Handle(new PrecenceCommand(1, 1), default);

            //assert
            await action.Should().ThrowAsync<ApplicationRequestException>();
        }

        [Fact]
        public async Task Should_execute_handler_not_found_person_laborer()
        {
            //arrange
            var personInterviewed = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType>() { PersonType.Assistido }, "nome", 123456789);
            var moq = new Mock<IPersonRegistrationRepository>();
            moq.Setup(x => x.GetByDocument(It.IsAny<long>(), It.IsAny<PersonType>())).Returns(personInterviewed);

            //act
            var commandHandler = new PrecenceCommandHandler(moq.Object);
            Func<Task<Unit>> action = async () => await commandHandler.Handle(new PrecenceCommand(1, 1), default);

            //assert
            await action.Should().ThrowAsync<ApplicationRequestException>();
        }
    }
}
