using FluentAssertions;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Application.Query;
using SL.Person.Registration.Application.Query.Validations;
using System;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query.Validations
{
    public class FindPersonByNameQueryValidationTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("")]
        public void Should_request_validate(string name)
        {
            //arrange
            var request = new FindPersonByNameQuery(name);
            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().Throw<HttpRequestException>();
        }

        [Fact]
        public void Should_request_is_valid()
        {
            //arrange
            var request = new FindPersonByNameQuery("teste");
            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().NotThrow<HttpRequestException>();
        }
    }
}
