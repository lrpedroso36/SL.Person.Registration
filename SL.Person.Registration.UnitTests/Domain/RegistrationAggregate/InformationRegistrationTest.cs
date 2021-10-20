﻿using System;
using System.Collections.Generic;
using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Domain.DonationAggregate;
using SL.Person.Registration.Domain.InterViewAggregate;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.RegistrationAggregate;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.RegistrationAggregate
{
    public class InformationRegistrationTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[] { Builder<PersonRegistration>.CreateNew().Build(),
                Builder<Interview>.CreateListOfSize(1).Build(),
                Builder<Donation>.CreateListOfSize(1).Build()
            },
            new object[]
            {
                Builder<PersonRegistration>.CreateNew().Build(),
                null,
                Builder<Donation>.CreateListOfSize(1).Build()

            },
            new object[]
            {
                Builder<PersonRegistration>.CreateNew().Build(),
                Builder<Interview>.CreateListOfSize(1).Build(),
                null
            },
            new object[]
            {
                Builder<PersonRegistration>.CreateNew().Build(),
                null,
                null
            }
        };

        [Theory]
        [MemberData(nameof(Data))]

        public void Should_set_properties(PersonRegistration personRegistration, List<Interview> interviews, List<Donation> donations)
        {
            var informationRegistration = InformationRegistration.CreateInstance(personRegistration, interviews, donations);

            informationRegistration.PersonRegistration.Should().BeEquivalentTo(personRegistration);

            informationRegistration.Interviews.Should().BeEquivalentTo(interviews);

            informationRegistration.Donations.Should().BeEquivalentTo(donations);
        }
    }
}
