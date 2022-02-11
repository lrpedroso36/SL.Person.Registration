using FluentAssertions;
using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Domain.Requests;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;
using SL.Person.Registration.UnitTests.Builder;
using System;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Validations
{
    public class InsertPersonCommandValidationTest
    {
        public static List<object[]> Data = new List<object[]>
        {
            new object[] { new InsertPersonCommand(null),
                           ResultBuilder.GetResult<bool>(ResourceMessagesValidation.InsertPersonCommandValidation_RequestInvalid, ErrorType.InvalidParameters)
            },
            new object[] { new InsertPersonCommand(new PersonRequest() { DocumentNumber = 0 }),
                           ResultBuilder.GetResult<bool>(ResourceMessagesValidation.InsertPersonCommandValidation_RequestInvalid, ErrorType.InvalidParameters)
            },
            new object[] { new InsertPersonCommand(new PersonRequest() { DocumentNumber = 1 }),
                           ResultBuilder.GetResult<bool>(String.Empty, 0)
            }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_request_validate(InsertPersonCommand request, Result<bool> resultExpected)
        {
            //arrange
            //act
            var result = request.RequestValidate();

            //assert
            result.Should().BeEquivalentTo(resultExpected);
        }
    }
}
