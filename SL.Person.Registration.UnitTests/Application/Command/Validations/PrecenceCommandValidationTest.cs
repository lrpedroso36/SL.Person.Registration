using FluentAssertions;
using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;
using SL.Person.Registration.UnitTests.Builder;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Validations
{
    public class PrecenceCommandValidationTest
    {
        public static List<object[]> Data = new List<object[]>
        {
            new object[] { new PrecenceCommand(0,1), ResultBuilder.GetResult<bool>(ResourceMessagesValidation.PrecenceCommandValidation_DataRequestInvalid, ErrorType.InvalidParameters) },
            new object[] { new PrecenceCommand(1,0), ResultBuilder.GetResult<bool>(ResourceMessagesValidation.PrecenceCommandValidation_DataRequestInvalid, ErrorType.InvalidParameters) },
            new object[] { new PrecenceCommand(0,0), ResultBuilder.GetResult<bool>(ResourceMessagesValidation.PrecenceCommandValidation_DataRequestInvalid, ErrorType.InvalidParameters) },
            new object[] { new PrecenceCommand(1,1), ResultBuilder.GetResult<bool>(string.Empty,0) }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_request_validate(PrecenceCommand request, Result<bool> resultExpected)
        {
            //arrange
            //act
            var result = request.RequestValidate();

            //assert
            result.Should().BeEquivalentTo(resultExpected);
        }
    }
}
