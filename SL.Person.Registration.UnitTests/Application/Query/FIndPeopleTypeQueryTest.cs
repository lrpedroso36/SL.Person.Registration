using FluentAssertions;
using SL.Person.Registration.Application.Query;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query
{
    public class FIndPeopleTypeQueryTEst
    {
        [Fact]
        public void Should_set_properties()
        {
            //arrange
            //act
            var query = new FindPeopleTypeQuery(PersonType.Entrevistador);

            //assert
            query.Type.Should().Be(PersonType.Entrevistador);
        }
    }
}
