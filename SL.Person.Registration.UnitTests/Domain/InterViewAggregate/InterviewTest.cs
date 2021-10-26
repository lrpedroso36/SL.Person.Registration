using System;
using System.Collections.Generic;
using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Domain.InterViewAggregate;
using SL.Person.Registration.Domain.InterViewAggregate.Enuns;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.InterViewAggregate
{
    public class InterviewTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[] { TreatmentType.PasseLimpeza,
                InterviewType.Primeira,
                new DateTime(2021,10,20),
                Builder<PersonRegistration>.CreateNew().Build(),
                1,
                "opinião",
                null,
                null,
            },
            new object[] { TreatmentType.PasseLimpeza,
                InterviewType.Primeira,
                new DateTime(2021,10,20),
                PersonRegistration.CreateInstance(
                    new List<PersonType> { PersonType.Assistido}, "nome", GenderType.Masculino, 1, 1234567890, null,null),
                1,
                "opinião",
                null,
                Builder<Presence>.CreateListOfSize(1).Build()
            },
            new object[]{ TreatmentType.PasseLimpeza,
                InterviewType.Primeira,
                new DateTime(2021,10,20),
                PersonRegistration.CreateInstance(
                    new List<PersonType> { PersonType.Entrevistador}, "nome", GenderType.Masculino, 1, 1234567890, null,null),
                1,
                "opinião",
                "nome",
                Builder<Presence>.CreateListOfSize(1).Build()
            }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_set_properties(TreatmentType treatmentType, InterviewType type, DateTime date,
            PersonRegistration person, int amount, string opinion, string interviewName, List<Presence> presences)
        {
            var interview = Interview.CreateInstance(treatmentType, type, date, person, amount, opinion, presences);

            interview.TreatmentType.Should().Be(treatmentType);

            interview.Type.Should().Be(type);

            interview.Date.Should().Be(date);

            interview.InterviewName.Should().Be(interviewName);

            interview.Opinion.Should().Be(opinion);
            interview.Opinion.Should().BeOfType(typeof(string));
        }
    }
}
