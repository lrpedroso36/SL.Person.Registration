using FluentAssertions;
using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Domain.Requests;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Validations
{
    public class InsertInterviewCommandValidationTest
    {
        public static List<object[]> Data = new List<object[]>
        {
            new object[] { new InsertInterviewCommand(null), GetResult(ResourceMessagesValidation.InsertInterviewCommandValidation_RequestInvalid, ErrorType.InvalidParameters) },
            new object[] { new InsertInterviewCommand(new InterviewRequest() { Interviewed = 0, Interviewer = 0 }),
                           GetResult(ResourceMessagesValidation.InsertInterviewCommandValidation_DataRequestInvalid, ErrorType.InvalidParameters)
            },
            new object[] { new InsertInterviewCommand(new InterviewRequest() { Interviewed = 1, Interviewer = 0 }),
                           GetResult(ResourceMessagesValidation.InsertInterviewCommandValidation_DataRequestInvalid, ErrorType.InvalidParameters)
            },
            new object[] { new InsertInterviewCommand(new InterviewRequest() { Interviewed = 0, Interviewer = 1 }),
                           GetResult(ResourceMessagesValidation.InsertInterviewCommandValidation_DataRequestInvalid, ErrorType.InvalidParameters)
            },
            new object[] { new InsertInterviewCommand(new InterviewRequest() { Interviewed = 1, Interviewer = 1 }),
                           GetResult(string.Empty, 0)
            }
        };

        public static Result GetResult(string errors, ErrorType errorType)
        {
            var result = new Result();
            result.AddErrors(errors, errorType);
            return result;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_request_validate(InsertInterviewCommand request, Result resultExpected)
        {
            //arrange
            //act
            var result = request.RequestValidate();

            //assert
            result.Should().BeEquivalentTo(resultExpected);
        }
    }
}
