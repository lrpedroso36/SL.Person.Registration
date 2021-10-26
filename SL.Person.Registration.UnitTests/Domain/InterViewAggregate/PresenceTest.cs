using System;
using System.Collections.Generic;
using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Domain.InterViewAggregate;
using SL.Person.Registration.Domain.PersonAggregate;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.InterViewAggregate
{
    public class PresenceTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[] { new DateTime(2021,10,25), null, null },
            new object[] { new DateTime(2021, 10, 25), Builder<PersonRegistration>.CreateNew().Build(), "Name" }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_set_properties(DateTime date, PersonRegistration taskMaster, string nameExpected)
        {
            var presence = Presence.CreateInstance(date, taskMaster);
            presence.Date.Should().Be(date);
            presence.TaskMaster.Should().Be(nameExpected);
        }
    }
}
