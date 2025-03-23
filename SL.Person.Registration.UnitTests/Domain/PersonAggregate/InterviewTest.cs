using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.PersonAggregate
{
    public class InterviewTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[] { TreatmentType.PasseLimpeza,
                WeakDayType.Sabado,
                InterviewType.Primeira,
                new DateTime(2021,10,20),
                PersonRegistration.CreateInstance(
                    new() { PersonType.Tarefeiro() }, "nome", GenderType.Masculino, new DateTime(1988,04,29), 1234567890),
                1,
                "opinião",
                null,
                GetTrataments(),
            },
            new object[] { TreatmentType.PasseLimpeza,
                WeakDayType.Sabado,
                InterviewType.Primeira,
                new DateTime(2021,10,20),
                PersonRegistration.CreateInstance(
                    new() { PersonType.Tarefeiro() }, "nome", GenderType.Masculino, new DateTime(1988,04,29), 1234567890),
                1,
                "opinião",
                null,
                GetTrataments()
            },
            new object[]{ TreatmentType.PasseLimpeza,
                WeakDayType.Sabado,
                InterviewType.Primeira,
                new DateTime(2021,10,20),
                PersonRegistration.CreateInstance(
                    new() { PersonType.Tarefeiro() }, "nome", GenderType.Masculino, new DateTime(1988,04,29) , 1234567890),
                1,
                "opinião",
                PersonRegistration.CreateInstanceSimple(Guid.Empty, new() { PersonType.Tarefeiro() }, "nome",1234567890),
                GetTrataments()
            }
        };

        public static List<Tratament> GetTrataments()
        {
            return new List<Tratament>() { Tratament.CreateInstance(new DateTime(2021, 10, 23)) };
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_set_properties(TreatmentType treatmentType, WeakDayType weakDayType, InterviewType type, DateTime date,
            PersonRegistration person, int amount, string opinion, PersonRegistration interviewer, List<Tratament> presences)
        {
            //arrange
            //act
            var interview = Interview.CreateInstance(treatmentType, weakDayType, type, date, person, amount, opinion);

            //assert
            interview.TreatmentType.Should().Be(treatmentType);

            interview.WeakDayType.Should().Be(weakDayType);

            interview.InterviewType.Should().Be(type);

            interview.Date.Should().Be(date);

            interview.Opinion.Should().Be(opinion);
            interview.Opinion.Should().BeOfType(typeof(string));

            interview.Trataments.Should().BeEquivalentTo(presences);
        }

        [Fact]
        public void Should_set_trataments()
        {
            //arrange
            var trataments = new List<Tratament>()
            {
                Tratament.CreateInstance(new DateTime(2022,02,12)),
                Tratament.CreateInstance(new DateTime(2022,02,19))
            };

            //act
            var interview = Interview.CreateInstance(TreatmentType.PasseA3, WeakDayType.Sabado, InterviewType.Retorno, new DateTime(2022, 02, 09),
                GetPersonRegistration(), 2, "teste opniao");

            //assert
            interview.Trataments.Should().BeEquivalentTo(trataments);
        }

        public static PersonRegistration GetPersonLaborer()
        {
            var person = Builder<PersonRegistration>.CreateNew().Build();
            person.AddPersonType(PersonType.Tarefeiro());
            return PersonRegistration.CreateInstanceSimple(person.Id, [.. person.PersonRegistrationPersonTypes.Select(x => x.PersonType)], person.Name, person.DocumentNumber);
        }

        public static PersonRegistration GetPersonRegistration()
        {
            var person = Builder<PersonRegistration>.CreateNew().Build();
            person.AddPersonType(Builder<PersonType>.CreateNew().Build());
            return person;
        }

        [Fact]
        public void Should_set_presence_tratament()
        {
            //arrange
            var laborer = GetPersonLaborer();

            var interview = Interview.CreateInstance(TreatmentType.PasseA3, WeakDayType.Sabado, InterviewType.Retorno, new DateTime(2022, 02, 09),
                GetPersonRegistration(), 2, "teste opniao");

            var trataments = new List<Tratament>()
            {
                Tratament.CreateInstance(new DateTime(2022, 2, 10), true),
                Tratament.CreateInstance(new DateTime(2022, 2, 19))
            };

            //act
            interview.SetPresenceTratament(new DateTime(2022, 2, 10));

            //assert
            interview.Trataments.Should().BeEquivalentTo(trataments);
            interview.Status.Should().Be(TratamentStatus.InProcess);
        }

        [Fact]
        public void Should_not_set_presence_tratament_if_tratament_completed()
        {
            var laborer = GetPersonLaborer();

            var interview = Interview.CreateInstance(TreatmentType.PasseA3, WeakDayType.Sabado, InterviewType.Retorno, new DateTime(2022, 01, 09),
                GetPersonRegistration(), 2, "teste opniao");

            var trataments = new List<Tratament>()
            {
                Tratament.CreateInstance(new DateTime(2022, 2, 08), true),
                Tratament.CreateInstance(new DateTime(2022, 2, 09), true)
            };

            //act
            interview.SetPresenceTratament(new DateTime(2022, 2, 08));
            interview.SetPresenceTratament(new DateTime(2022, 2, 09));
            interview.SetPresenceTratament(new DateTime(2022, 2, 10));

            //assert
            interview.Trataments.Should().BeEquivalentTo(trataments);
            interview.Status.Should().Be(TratamentStatus.Concluded);
        }
    }
}
