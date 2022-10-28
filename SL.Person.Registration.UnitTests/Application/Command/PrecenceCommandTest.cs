using FluentAssertions;
using SL.Person.Registration.Application.Command.Precence;
using System;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command
{
    public class PrecenceCommandTest
    {
        [Fact]
        public void Should_set_properties()
        {
            //arrange
            var id = Guid.NewGuid().ToString();

            //act
            var command = new PrecenceCommand(id);

            //assert
            command.Id.Should().Be(id);
        }
    }
}
