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
            var documentInterviewe = 1;
            var documentTaskMaster = 1;

            //act
            var command = new PrecenceCommand(documentInterviewe, documentTaskMaster);

            //assert
            command.Interviewed.Should().Be(documentInterviewe);
            command.TaskMaster.Should().Be(documentTaskMaster);
        }
    }
}
