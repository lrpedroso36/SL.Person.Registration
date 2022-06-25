using FluentAssertions;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Application.Query;
using SL.Person.Registration.Application.Query.Validations;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query.Validations
{
    public class FindPeopleTypeQueryValidationTest
    {
        [Fact]
        public void Should_request_not_valid()
        {
            //arrange
            var request = new FindPeopleTypeQuery(0);
            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().Throw<ApplicationRequestException>();
        }
    }
}
