using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Domain.PersonAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.PersonAggregate
{
    public class TratamentTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[] { new DateTime(2021,10,25) },
            new object[] { new DateTime(2021, 10, 25) },
            new object[] { new DateTime(2021,10,25) }
        };

        public static PersonRegistration GetPersonRegistration()
        {
            var person = Builder<PersonRegistration>.CreateNew().Build();
            person.AddPersonType(PersonType.Tarefeiro());
            return PersonRegistration.CreateInstanceSimple(person.Id, [.. person.PersonRegistrationPersonTypes.Select(x => x.PersonType)], person.Name, person.DocumentNumber);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_set_properties(DateTime date)
        {
            //arrange
            //act
            var presence = Tratament.CreateInstance(date);

            //assert
            presence.Date.Should().Be(date);
        }
    }
}
