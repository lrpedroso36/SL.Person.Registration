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
    public class InsertPersonCommandValidationTest
    {
        public static List<object[]> Data = new List<object[]>
        {
            new object[] { new InsertPersonCommand(null) },
            new object[] { new InsertPersonCommand(new PersonRequest() { DocumentNumber = 0 }) }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_request_invalid(InsertPersonCommand request)
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
            var request = new InsertPersonCommand(new PersonRequest() { DocumentNumber = 1 });

            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().NotThrow<ApplicationRequestException>();
        }
    }
}
