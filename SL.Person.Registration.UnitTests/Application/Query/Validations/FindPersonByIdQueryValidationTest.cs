﻿using FluentAssertions;
using SL.Person.Registration.Application.Commons.Exceptions;
using SL.Person.Registration.Application.Query.FindPersonById;
using SL.Person.Registration.Application.Query.FindPersonById.Extensions;
using System;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query.Validations
{
    public class FindPersonByIdQueryValidationTest
    {
        [Theory]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("asdas")]
        public void Should_request_not_valid(string id)
        {
            //arrange
            var request = new FindPersonByIdQuery(id);
            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().Throw<ApplicationRequestException>();
        }

        [Fact]
        public void Should_request_is_valid()
        {
            //arrange
            var request = new FindPersonByIdQuery(Guid.NewGuid().ToString());
            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().NotThrow<ApplicationRequestException>();
        }
    }
}
