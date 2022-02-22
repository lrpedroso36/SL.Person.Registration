using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.PersonAggregate
{
    public class TratamentTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[] { new DateTime(2021,10,25), null, null },
            new object[] { new DateTime(2021, 10, 25), GetPersonRegistration() , GetPersonRegistration() },
            new object[] { new DateTime(2021,10,25), Builder<PersonRegistration>.CreateNew().Build(), null}
        };

        public static PersonRegistration GetPersonRegistration()
        {
            var person = Builder<PersonRegistration>.CreateNew().Build();
            person.AddPersonType(PersonType.Tarefeiro);
            return PersonRegistration.CreateInstanceSimple(person._id, person.Types, person.Name, person.DocumentNumber);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_set_properties(DateTime date, PersonRegistration laborer, PersonRegistration laborerExpected)
        {
            //arrange
            //act
            var presence = Tratament.CreateInstance(date, laborer);

            //assert
            presence.Date.Should().Be(date);
            presence.Laborer.Should().BeEquivalentTo(laborerExpected);
        }

        [Fact]
        public void Should_set_presence()
        {
            //arrange
            var date = new DateTime(2022, 2, 10);
            var laborer = GetPersonRegistration();
            var tratament = Builder<Tratament>.CreateNew().Build();

            //act
            tratament.SetPresence(date, laborer);

            //assert
            tratament.Date.Should().Be(date);
            tratament.Laborer.Should().BeEquivalentTo(laborer);
            tratament.Presence.Should().BeTrue();
        }
    }
}
