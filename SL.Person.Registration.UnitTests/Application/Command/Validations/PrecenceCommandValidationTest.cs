using FluentAssertions;
using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Validations
{
    public class PrecenceCommandValidationTest
    {
        public static List<object[]> Data = new List<object[]>
        {
            new object[] { new PrecenceCommand(0,1), GetResult(ResourceMessagesValidation.PrecenceCommandValidation_DataRequestInvalid, ErrorType.InvalidParameters) },
            new object[] { new PrecenceCommand(1,0), GetResult(ResourceMessagesValidation.PrecenceCommandValidation_DataRequestInvalid, ErrorType.InvalidParameters) },
            new object[] { new PrecenceCommand(0,0), GetResult(ResourceMessagesValidation.PrecenceCommandValidation_DataRequestInvalid, ErrorType.InvalidParameters) },
            new object[] { new PrecenceCommand(1,1), GetResult(string.Empty,0) }
        };

        public static Result GetResult(string errors, ErrorType errorType)
        {
            var result = new Result();
            result.AddErrors(errors, errorType);
            return result;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_request_validate(PrecenceCommand request, Result resultExpected)
        {
            //arrange
            //act
            var result = request.RequestValidate();

            //assert
            result.Should().BeEquivalentTo(resultExpected);
        }
    }
}
