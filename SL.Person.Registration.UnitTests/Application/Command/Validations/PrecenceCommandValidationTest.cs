using FluentAssertions;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Application.Exceptions;
using System;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Validations
{
    public class PrecenceCommandValidationTest
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("asdasdasd")]
        public void Should_request_invalid(string id)
        {
            //arrange
            var request = new PrecenceCommand(id);
            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().Throw<ApplicationRequestException>();
        }

        [Fact]
        public void Should_request_valid()
        {
            //arrange
            var request = new PrecenceCommand(Guid.NewGuid().ToString());

            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().NotThrow<ApplicationRequestException>();
        }
    }
}
