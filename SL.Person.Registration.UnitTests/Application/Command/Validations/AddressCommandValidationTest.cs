using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Command.Validations;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Domain.Requests;
using System;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Validations
{
    public class AddressCommandValidationTest
    {
        public static List<object[]> Data = new List<object[]>
        {
            new object[]
            {
               new AddressCommand(0, Builder<AddressRequest>.CreateNew().Build()),
            },
            new object[]
            {
               new AddressCommand(1234567890, null),
            }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_request_invalid(AddressCommand request)
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
            var request = new AddressCommand(1234567890, Builder<AddressRequest>.CreateNew().Build());

            //act
            Action action = () => request.RequestValidate();

            //assert
            action.Should().NotThrow<HttpRequestException>();
        }
    }
}
