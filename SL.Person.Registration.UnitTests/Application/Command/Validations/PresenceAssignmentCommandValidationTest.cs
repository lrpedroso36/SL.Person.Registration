using FluentAssertions;
using SL.Person.Registration.Application.Command.PresenceAssignment;
using SL.Person.Registration.Application.Exceptions;
using System;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Validations
{
    public class PresenceAssignmentCommandValidationTest
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("asdasd")]
        public void Should_request_invalid(string id)
        {
            //arrange
            var request = new PresenceAssignmentCommand(id);

            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().Throw<ApplicationRequestException>();
        }

        [Fact]
        public void Should_request_valid()
        {
            //arrange
            var request = new PresenceAssignmentCommand(Guid.NewGuid().ToString());

            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().NotThrow<ApplicationRequestException>();
        }
    }
}
