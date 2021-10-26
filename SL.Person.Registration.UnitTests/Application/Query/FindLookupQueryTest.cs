﻿using System;
using System.Collections.Generic;
using FluentAssertions;
using SL.Person.Registration.Application.Query;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query
{
    public class FindLookupQueryTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[] { 1.GetType() },
            new object[] { DateTime.Now.GetType() },
            new object[] { "teste".GetType() },

        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_set_properties(Type type)
        {
            var query = new FindLookupQuery(type);
            query.EnumType.Should().Be(type);
        }
    }
}