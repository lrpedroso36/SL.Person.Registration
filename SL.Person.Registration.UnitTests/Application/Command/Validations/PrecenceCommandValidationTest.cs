using FluentAssertions;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Application.Exceptions;
using System;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Validations
{
    public class PrecenceCommandValidationTest
    {
        public static List<object[]> Data = new List<object[]>
        {
            new object[] { new PrecenceCommand(0,1) },
            new object[] { new PrecenceCommand(1,0) },
            new object[] { new PrecenceCommand(0,0) }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_request_invalid(PrecenceCommand request)
        {
            //arrange
            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().Throw<HttpRequestException>();
        }

        [Fact]
        public void Should_request_valid()
        {
            //arrange
            var request = new PrecenceCommand(1, 1);

            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().NotThrow<HttpRequestException>();
        }
    }
}
