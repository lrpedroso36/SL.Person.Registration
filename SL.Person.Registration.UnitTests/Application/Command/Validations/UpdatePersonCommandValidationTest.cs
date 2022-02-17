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
    public class UpdatePersonCommandValidationTest
    {
        public static List<object[]> Data = new List<object[]>
        {
            new object[] { new UpdatePersonCommand(null),
                           GetResult(ResourceMessagesValidation.UpdatePersonCommandValidation_RequestInvalid, ErrorType.InvalidParameters)
            },
            new object[] { new UpdatePersonCommand(new PersonRequest() { DocumentNumber = 0 }),
                           GetResult(ResourceMessagesValidation.UpdatePersonCommandValidation_RequestInvalid, ErrorType.InvalidParameters)
            },
            new object[] { new UpdatePersonCommand(new PersonRequest() { DocumentNumber = 1 }),
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
        public void Should_request_validate(UpdatePersonCommand request, Result resultExpected)
        {
            //arrange
            //act
            var result = request.RequestValidate();

            //assert
            result.Should().BeEquivalentTo(resultExpected);
        }
    }
}
