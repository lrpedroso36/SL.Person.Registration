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
                    new List<PersonType> { PersonType.Assistido}, "nome", GenderType.Masculino, 1, 1234567890, null,null),
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
                    new List<PersonType> { PersonType.Entrevistador}, "nome", GenderType.Masculino, 1, 1234567890, null,null),
                1,
                "opinião",
                PersonRegistration.CreateInstance(
                    new List<PersonType> { PersonType.Entrevistador}, "nome", GenderType.Masculino, 1, 1234567890, null,null),
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
            var interview = Interview.CreateInstance(treatmentType, weakDayType, type, date, person, amount, opinion);

            interview.TreatmentType.Should().Be(treatmentType);

            interview.WeakDayType.Should().Be(weakDayType);

            interview.Type.Should().Be(type);

            interview.Date.Should().Be(date);

            interview.Interviewer.Should().BeEquivalentTo(interviewer);

            interview.Opinion.Should().Be(opinion);
            interview.Opinion.Should().BeOfType(typeof(string));

            interview.Trataments.Should().BeEquivalentTo(presences);
        }
    }
}
