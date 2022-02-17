using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Domain.Requests;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;
using System;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Validations
{
    public class AddressCommandValidationTest
    {
        public static List<object[]> Data = new List<object[]>
        {
            new object[]
            {
               new AddressCommand(0, Builder<AddressRequest>.CreateNew().Build()),
               GetResult(ResourceMessagesValidation.AddressCommandValidation_RequestInvalid_Document, ErrorType.InvalidParameters)
            },
            new object[]
            {
               new AddressCommand(1234567890, null),
               GetResult(ResourceMessagesValidation.AddressCommandValidation_RequestInvalid, ErrorType.InvalidParameters)
            },
            new object[]
            {
               new AddressCommand(1234567890, Builder<AddressRequest>.CreateNew().Build()),
               GetResult(String.Empty, 0)
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
        public void Should_request_validate(AddressCommand request, Result resultExpected)
        {
            //arrange
            //act
            var result = request.RequestValidate();

            //assert
            result.Should().BeEquivalentTo(resultExpected);
        }
    }
}
