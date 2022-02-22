using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System;
using System.Collections.Generic;
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
                Builder<PersonRegistration>.CreateNew().Build(),
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
                    new List<PersonType> { PersonType.Assistido}, "nome", GenderType.Masculino, 1, 1234567890),
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
                    new List<PersonType> { PersonType.Entrevistador}, "nome", GenderType.Masculino, 1, 1234567890),
                1,
                "opinião",
                PersonRegistration.CreateInstanceSimple(Guid.Empty, new List<PersonType> { PersonType.Entrevistador}, "nome",1234567890),
                GetTrataments()
            }
        };

        public static List<Tratament> GetTrataments()
        {
            return new List<Tratament>() { Tratament.CreateInstance(new DateTime(2021, 10, 23), null) };
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

            interview.Type.Should().Be(type);

            interview.Date.Should().Be(date);

            interview.Interviewer.Should().BeEquivalentTo(interviewer);

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
                Tratament.CreateInstance(new DateTime(2022,02,12), null),
                Tratament.CreateInstance(new DateTime(2022,02,19), null)
            };

            //act
            var interview = Interview.CreateInstance(TreatmentType.PasseA3, WeakDayType.Sabado, InterviewType.Retorno, new DateTime(2022, 02, 09),
                Builder<PersonRegistration>.CreateNew().Build(), 2, "teste opniao");

            //assert
            interview.Trataments.Should().BeEquivalentTo(trataments);
        }

        public static PersonRegistration GetPersonLaborer()
        {
            var person = Builder<PersonRegistration>.CreateNew().Build();
            person.AddPersonType(PersonType.Tarefeiro);
            return PersonRegistration.CreateInstanceSimple(person._id, person.Types, person.Name, person.DocumentNumber);
        }

        [Fact]
        public void Should_set_presence_tratament()
        {
            //arrange
            var laborer = GetPersonLaborer();

            var interview = Interview.CreateInstance(TreatmentType.PasseA3, WeakDayType.Sabado, InterviewType.Retorno, new DateTime(2022, 02, 09),
                Builder<PersonRegistration>.CreateNew().Build(), 2, "teste opniao");

            var trataments = new List<Tratament>()
            {
                Tratament.CreateInstance(new DateTime(2022, 2, 10), laborer, true),
                Tratament.CreateInstance(new DateTime(2022, 2, 19), null)
            };

            //act
            interview.SetPresenceTratament(new DateTime(2022, 2, 10), laborer);

            //assert
            interview.Trataments.Should().BeEquivalentTo(trataments);
            interview.Status.Should().Be(TratamentStatus.InProcess);
        }

        [Fact]
        public void Should_not_set_presence_tratament_if_tratament_completed()
        {
            var laborer = GetPersonLaborer();

            var interview = Interview.CreateInstance(TreatmentType.PasseA3, WeakDayType.Sabado, InterviewType.Retorno, new DateTime(2022, 01, 09),
                Builder<PersonRegistration>.CreateNew().Build(), 2, "teste opniao");

            var trataments = new List<Tratament>()
            {
                Tratament.CreateInstance(new DateTime(2022, 2, 08), laborer, true),
                Tratament.CreateInstance(new DateTime(2022, 2, 09), laborer, true)
            };

            //act
            interview.SetPresenceTratament(new DateTime(2022, 2, 08), laborer);
            interview.SetPresenceTratament(new DateTime(2022, 2, 09), laborer);
            interview.SetPresenceTratament(new DateTime(2022, 2, 10), laborer);

            //assert
            interview.Trataments.Should().BeEquivalentTo(trataments);
            interview.Status.Should().Be(TratamentStatus.Concluded);
        }
    }
}
