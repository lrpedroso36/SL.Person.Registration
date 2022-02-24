using FluentAssertions;
using SL.Person.Registration.Application.Command;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command
{
    public class PresenceAssignmentCommandTest
    {
        [Fact]
        public void Should_set_laborer_document()
        {
            //arrange
            var laborerDocument = 1234567890;
            //act
            var command = new PresenceAssignmentCommand(laborerDocument);

            //assert
            command.LaborerDocument.Should().Be(laborerDocument);
        }
    }
}
