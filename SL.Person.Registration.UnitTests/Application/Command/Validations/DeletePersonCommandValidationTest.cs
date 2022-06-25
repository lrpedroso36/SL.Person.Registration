using FluentAssertions;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Application.Exceptions;
using System;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Validations
{
    public class DeletePersonCommandValidationTest
    {
        [Fact]
        public void Should_request_invalid()
        {
            //arrange
            var request = new DeletePersonCommand(0);

            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().Throw<ApplicationRequestException>();
        }

        [Fact]
        public void Should_request_valid()
        {
            //arrange
            var request = new DeletePersonCommand(1234567890);

            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().NotThrow<ApplicationRequestException>();
        }
    }
}
