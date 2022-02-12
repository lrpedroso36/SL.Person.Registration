using FluentAssertions;
using SL.Person.Registration.Domain.PersonAggregate;
using System;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.PersonAggregate
{
    public class AssignmentTest
    {
        [Fact]
        public void Should_set_properties()
        {
            //arrange
            var date = new DateTime(2022, 02, 12);
            var presence = true;

            //act 
            var assignment = Assignment.CreateInstance(date, presence);

            //assert
            assignment.Date.Should().Be(date);
            assignment.Presence.Should().Be(presence);
        }
    }
}
