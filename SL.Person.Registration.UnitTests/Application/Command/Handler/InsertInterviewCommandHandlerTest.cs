﻿using FizzWare.NBuilder;
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
        public static List<object[]> Data = new List<object[]>
        {
            new object[] { new InsertInterviewCommand(Builder<InterviewRequest>.CreateNew().Build()),
                           2,
                           Builder<PersonRegistration>.CreateNew().Build(),
                           PersonRegistration.CreateInstanceSimple(Guid.NewGuid(), new List<PersonType>() { PersonType.Entrevistador }, "nome", 123456789)
            }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public async Task Should_execute_handler(InsertInterviewCommand command, int atMostInsert,
            PersonRegistration personRegistration, PersonRegistration personInterview)
        {
            //arrange
            var moq = new Mock<IPersonRegistrationRepository>();
            moq.Setup(x => x.GetByDocument(It.IsAny<long>())).Returns(personRegistration);
            moq.Setup(x => x.GetByDocument(It.IsAny<long>(), It.IsAny<PersonType>())).Returns(personInterview);

            //act
            var commandHandler = new InsertInterviewCommandHandler(moq.Object);
            var result = await commandHandler.Handle(command, default);

            //assert
            moq.Verify(x => x.Insert(It.IsAny<PersonRegistration>()), Times.AtMost(atMostInsert));
        }

        public static List<object[]> DataInvalid = new List<object[]>()
        {
            new object[] { new InsertInterviewCommand(null) },
            new object[] { new InsertInterviewCommand(new InterviewRequest() { Interviewed = 1, Interviewer = 0 })},
            new object[] { new InsertInterviewCommand(new InterviewRequest() { Interviewed = 0, Interviewer = 1 })},
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
            Func<Task<Unit>> action = async () => await commandHandler.Handle(new InsertInterviewCommand(new InterviewRequest() { Interviewed = 1, Interviewer = 1 }), default);

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
            Func<Task<Unit>> action = async () => await commandHandler.Handle(new InsertInterviewCommand(new InterviewRequest() { Interviewed = 1, Interviewer = 1 }), default);

            //assert
            await action.Should().ThrowAsync<ApplicationRequestException>();
        }
    }
}
