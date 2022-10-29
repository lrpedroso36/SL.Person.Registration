using FluentAssertions;
using SL.Person.Registration.Application.Command.InsertInterview;
using SL.Person.Registration.Application.Command.InsertInterview.Extensions;
using SL.Person.Registration.Application.Commons.Exceptions;
using SL.Person.Registration.Application.Commons.Requests;
using System;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Validations
{
    public class InsertInterviewCommandValidationTest
    {
        public static List<object[]> Data = new List<object[]>
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
        [MemberData(nameof(Data))]
        public void Should_request_invalid(InsertInterviewCommand request)
        {
            //arrange
            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().Throw<ApplicationRequestException>();
        }

        [Fact]
        public void Should_request_valid()
        {
            //arrange
            var request = new InsertInterviewCommand(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), new InterviewRequest());
            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().NotThrow<ApplicationRequestException>();
        }
    }
}
