using FluentAssertions;
using SL.Person.Registration.Application.Command;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command
{
    public class DeletePersonCommandTest
    {
        [Fact]
        public void Should_set_laborer_document()
        {
            //arrange
            var document = 1234567890;
            //act
            var command = new DeletePersonCommand(document);

            //assert
            command.DocumentNumber.Should().Be(document);
        }
    }
}
