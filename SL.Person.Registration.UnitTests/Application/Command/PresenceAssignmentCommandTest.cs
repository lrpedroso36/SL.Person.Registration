using FluentAssertions;
using SL.Person.Registration.Application.Command;
using System;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command
{
    public class PresenceAssignmentCommandTest
    {
        [Fact]
        public void Should_set_laborer_document()
        {
            //arrange
            var id = Guid.NewGuid().ToString();
            //act
            var command = new PresenceAssignmentCommand(id);

            //assert
            command.Id.Should().Be(id);
        }
    }
}
