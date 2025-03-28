﻿using FizzWare.NBuilder;
using FluentAssertions;
using MediatR;
using Moq;
using SL.Person.Registration.Application.Command.InsertInterview;
using SL.Person.Registration.Application.Commons.Exceptions;
using SL.Person.Registration.Application.Commons.Requests;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Repositories;
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
            var interviewId = Guid.NewGuid();
            var command = new InsertInterviewCommand(Guid.NewGuid().ToString(), interviewId.ToString(), Builder<InterviewRequest>.CreateNew().Build());
            var atMostInsert = 2;
            var personRegistration = Builder<PersonRegistration>.CreateNew().Build();
            var personInterview = PersonRegistration.CreateInstanceSimple(interviewId, new List<PersonType>() { PersonType.Entrevistador() }, "nome", 123456789);

            var moq = new Mock<IPersonRegistrationRepository>();
            moq.Setup(x => x.GetByIdAsync(It.IsAny<string>(), default)).ReturnsAsync(personRegistration);
            moq.Setup(x => x.GetByIdAsync(It.IsAny<string>(), default)).ReturnsAsync(personInterview);

            //act
            var commandHandler = new InsertInterviewCommandHandler(moq.Object);
            var result = await commandHandler.Handle(command, default);

            //assert
            moq.Verify(x => x.InsertAsync(It.IsAny<PersonRegistration>(), default), Times.AtMost(atMostInsert));
            moq.Verify(x => x.UpdateAsync(It.IsAny<PersonRegistration>(), default), Times.Once);
        }

        public static List<object[]> DataInvalid = new List<object[]>()
        {
            new object[] { new InsertInterviewCommand("", Guid.NewGuid().ToString(), null) },
            new object[] { new InsertInterviewCommand(" ", Guid.NewGuid().ToString(), new InterviewRequest()) },
            new object[] { new InsertInterviewCommand(null, Guid.NewGuid().ToString(), new InterviewRequest()) },
            new object[] { new InsertInterviewCommand("asdasdasd", Guid.NewGuid().ToString(), new InterviewRequest()) },

            new object[] { new InsertInterviewCommand(Guid.NewGuid().ToString(), "",  null) },
            new object[] { new InsertInterviewCommand(Guid.NewGuid().ToString(), " ",  new InterviewRequest()) },
            new object[] { new InsertInterviewCommand(Guid.NewGuid().ToString(), null,  new InterviewRequest()) },
            new object[] { new InsertInterviewCommand(Guid.NewGuid().ToString(), "asdasdasd", new InterviewRequest()) }
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
    }
}
