using FluentAssertions;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Domain.Requests;
using System;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Validations
{
    public class InsertInterviewCommandValidationTest
    {
        public static List<object[]> Data = new List<object[]>
        {
            new object[] { new InsertInterviewCommand(null) },
            new object[] { new InsertInterviewCommand(new InterviewRequest() { Interviewed = 0, Interviewer = 0 }) },
            new object[] { new InsertInterviewCommand(new InterviewRequest() { Interviewed = 1, Interviewer = 0 }) },
            new object[] { new InsertInterviewCommand(new InterviewRequest() { Interviewed = 0, Interviewer = 1 }) }
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
            var request = new InsertInterviewCommand(new InterviewRequest() { Interviewed = 1, Interviewer = 1 });
            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().NotThrow<ApplicationRequestException>();
        }
    }
}
