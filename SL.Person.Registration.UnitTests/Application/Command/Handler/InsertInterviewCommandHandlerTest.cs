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
using SL.Person.Registration.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Handler
{
    public class InsertInterviewCommandHandlerTest
    {
        [Fact]
        public async Task Should_execute_handler()
        {
            //arrange
            var command = new InsertInterviewCommand(1, 1, Builder<InterviewRequest>.CreateNew().Build());
            var atMostInsert = 2;
            var personRegistration = Builder<PersonRegistration>.CreateNew().Build();
            var personInterview = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType>() { PersonType.Entrevistador }, "nome", 123456789);

            var moq = new Mock<IPersonRegistrationRepository>();
            moq.Setup(x => x.GetByDocument(It.IsAny<long>())).Returns(personRegistration);
            moq.Setup(x => x.GetByDocument(It.IsAny<long>(), It.IsAny<PersonType>())).Returns(personInterview);

            //act
            var commandHandler = new InsertInterviewCommandHandler(moq.Object);
            var result = await commandHandler.Handle(command, default);

            //assert
            moq.Verify(x => x.Insert(It.IsAny<PersonRegistration>()), Times.AtMost(atMostInsert));
            moq.Verify(x => x.Update(It.IsAny<PersonRegistration>()), Times.Once);
        }

        public static List<object[]> DataInvalid = new List<object[]>()
        {
            new object[] { new InsertInterviewCommand(0, 0, null) },
            new object[] { new InsertInterviewCommand(0, 0, new InterviewRequest()) },
            new object[] { new InsertInterviewCommand(1, 0, new InterviewRequest()) },
            new object[] { new InsertInterviewCommand(0, 1, new InterviewRequest()) }
        };

        [Theory]
        [MemberData(nameof(DataInvalid))]
        public async Task Should_execute_handler_invalid_request(InsertInterviewCommand command)
        {
            //arrange
            //act
            var commandHandler = new InsertInterviewCommandHandler(null);
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
            var commandHandler = new InsertInterviewCommandHandler(moq.Object);
            Func<Task<Unit>> action = async () => await commandHandler.Handle(new InsertInterviewCommand(1, 1, new InterviewRequest()), default);

            //assert
            await action.Should().ThrowAsync<ApplicationRequestException>();
        }

        [Fact]
        public async Task Should_execute_handler_not_found_person_interviewer()
        {
            //arrange
            var personInterviewed = PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType>() { PersonType.Assistido }, "nome", 123456789);
            var moq = new Mock<IPersonRegistrationRepository>();
            moq.Setup(x => x.GetByDocument(It.IsAny<long>(), It.IsAny<PersonType>())).Returns(personInterviewed);

            //act
            var commandHandler = new InsertInterviewCommandHandler(moq.Object);
            Func<Task<Unit>> action = async () => await commandHandler.Handle(new InsertInterviewCommand(1, 1, new InterviewRequest()), default);

            //assert
            await action.Should().ThrowAsync<ApplicationRequestException>();
        }
    }
}
