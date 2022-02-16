using FizzWare.NBuilder;
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
    public class ContactCommandValidationTest
    {
        public static List<object[]> Data = new List<object[]>
        {
            new object[]
            {
               new ContactCommand(0, Builder<ContactRequest>.CreateNew().Build()),
               ResultBuilder.GetResult<bool>(ResourceMessagesValidation.ContactCommandValidation_RequestInvalid_Document, ErrorType.InvalidParameters)
            },
            new object[]
            {
               new ContactCommand(1234567890, null),
               ResultBuilder.GetResult<bool>(ResourceMessagesValidation.ContactCommandValidation_RequestInvalid, ErrorType.InvalidParameters)
            },
            new object[]
            {
               new ContactCommand(1234567890, Builder<ContactRequest>.CreateNew().Build()),
               ResultBuilder.GetResult<bool>(String.Empty, 0)
            }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_request_validate(ContactCommand request, Result<bool> resultExpected)
        {
            //arrange
            //act
            var result = request.RequestValidate();

            //assert
            result.Should().BeEquivalentTo(resultExpected);
        }
    }
}
