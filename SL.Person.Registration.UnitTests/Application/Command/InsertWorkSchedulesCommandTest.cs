using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Application.Command;
using System;
using System.Linq;
using Xunit;
using static SL.Person.Registration.Application.Command.InsertWorkSchedulesCommand;

namespace SL.Person.Registration.UnitTests.Application.Command
{
    public class InsertWorkSchedulesCommandTest
    {
        [Fact]
        public void Should_set_properties()
        {
            //arrange
            var id = Guid.NewGuid().ToString();
            var works = Builder<WorkScheduleCommand>.CreateListOfSize(2).Build().ToList();

            //act
            var command = new InsertWorkSchedulesCommand(id, works);

            //assert
            command.Id.Should().Be(id);
            command.Works.Should().BeEquivalentTo(works);
        }
    }
}
