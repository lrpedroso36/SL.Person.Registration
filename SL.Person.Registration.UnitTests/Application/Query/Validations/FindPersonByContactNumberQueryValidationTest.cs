using FluentAssertions;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Application.Query;
using SL.Person.Registration.Application.Query.Validations;
using System;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query.Validations
{
    public class FindPersonByContactNumberQueryValidationTest
    {
        [Theory]
        [InlineData(0, 0L)]
        [InlineData(1, 0L)]
        [InlineData(0, 1L)]
        public void Should_request_not_valid(int ddd, long phoneNumber)
        {
            //arrange
            var request = new FindPersonByContactNumberQuery(ddd, phoneNumber);
            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().Throw<HttpRequestException>();
        }

        [Fact]
        public void Should_request_is_valid()
        {
            //arrange
            var request = new FindPersonByContactNumberQuery(1, 1L);
            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().NotThrow<HttpRequestException>();
        }
    }
}
