using FluentAssertions;
using SL.Person.Registration.Application.Query.FindPersonById;
using System;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query
{
    public class FindPersonByIdQueryTest
    {
        [Fact]
        public void Should_set_properties()
        {
            //arrange
            var id = Guid.NewGuid().ToString();
            //act
            var query = new FindPersonByIdQuery(id);

            //assert
            query.Id.Should().Be(id);
        }
    }
}
