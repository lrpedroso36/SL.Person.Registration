using FluentAssertions;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.PersonAggregate
{
    public class WorkScheduleTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[] { WeakDayType.QuintaFeira, new DateTime(2021,10,25), true },
            new object[] { WeakDayType.QuintaFeira, new DateTime(2021,10,25), false }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_set_properties(WeakDayType weakDayType, DateTime date, bool doTheReading)
        {
            //arrange
            //act
            var workSchedule = WorkSchedule.CreateInstance(weakDayType, date, doTheReading);

            //assert
            workSchedule.WeakDayType.Should().Be(weakDayType);
            workSchedule.Date.Should().Be(date);
            workSchedule.DoTheReading.Should().Be(doTheReading);
        }
    }
}
