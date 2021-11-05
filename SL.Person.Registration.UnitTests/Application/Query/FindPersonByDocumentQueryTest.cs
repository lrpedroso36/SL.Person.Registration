﻿using FluentAssertions;
using SL.Person.Registration.Application.Query;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query
{
    public class FindPersonByDocumentQueryTest
    {
        [Theory]
        [InlineData(1234567890)]
        public void Should_set_properties(long documentNumber)
        {
            var query = new FindPersonByDocumentQuery(documentNumber);
            query.DocumentNumber.Should().Be(documentNumber);
            query.DocumentNumber.Should().NotBe(0);
        }
    }
}