using FluentAssertions;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Application.Query;
using SL.Person.Registration.Application.Query.Validations;
using System;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query.Validations
{
    public class FindPersonByDocumentQueryValidationTest
    {
        [Fact]
        public void Should_request_not_valid()
        {
            //arrange
            var request = new FindPersonByDocumentQuery(0);
            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().Throw<HttpRequestException>();
        }

        [Fact]
        public void Should_request_is_valid()
        {
            //arrange
            var request = new FindPersonByDocumentQuery(1L);
            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().NotThrow<HttpRequestException>();
        }
    }
}
