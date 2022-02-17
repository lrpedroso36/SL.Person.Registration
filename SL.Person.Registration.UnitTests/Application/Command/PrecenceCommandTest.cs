using FluentAssertions;
using SL.Person.Registration.Application.Command;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command
{
    public class PrecenceCommandTest
    {
        [Fact]
        public void Should_set_properties()
        {
            //arrange
            var interviewDocument = 1;
            var laborerDocument = 1;

            //act
            var command = new PrecenceCommand(interviewDocument, laborerDocument);

            //assert
            command.InterviewedDocument.Should().Be(interviewDocument);
            command.LaborerDocument.Should().Be(laborerDocument);
        }
    }
}
