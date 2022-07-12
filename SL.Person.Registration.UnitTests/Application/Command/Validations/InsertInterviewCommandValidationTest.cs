using FluentAssertions;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Application.Requests;
using System;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Validations
{
    public class InsertInterviewCommandValidationTest
    {
        public static List<object[]> Data = new List<object[]>
        {
            new object[] { new InsertInterviewCommand(0, 0, null) },
            new object[] { new InsertInterviewCommand(0, 0, new InterviewRequest()) },
            new object[] { new InsertInterviewCommand(1, 0, new InterviewRequest()) },
            new object[] { new InsertInterviewCommand(0, 1, new InterviewRequest()) }
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
            var request = new InsertInterviewCommand(1, 1, new InterviewRequest());
            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().NotThrow<ApplicationRequestException>();
        }
    }
}
