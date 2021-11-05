﻿using System.Collections.Generic;
using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Domain.Requests;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command
{
    public class UpdatePersonCommandTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[] { new UpdatePersonCommand(null), null },
            new object[] { new UpdatePersonCommand(Builder<PersonRequest>.CreateNew().Build()), Builder<PersonRequest>.CreateNew().Build() }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_set_properties(UpdatePersonCommand command, PersonRequest personRequest)
        {
            command.Person.Should().BeEquivalentTo(personRequest);
        }
    }
}