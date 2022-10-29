using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Application.Commons.Exceptions;
using SL.Person.Registration.Application.Query.FindAddressByZipCode.Extensions;
using SL.Person.Registration.Domain.External.Response;
using System;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Extensions
{
    public class AddressResponseExtensionsTest
    {
        [Fact]
        public void Should_validate_instance()
        {
            //arrange 
            AddressResponse addressResponse = null;

            //act
            Action action = () => addressResponse.ValidateInstance();

            //assert
            action.Should().Throw<ApplicationRequestException>();
        }

        [Fact]
        public void Should_valid_instance()
        {
            //arrange 
            var addressResponse = Builder<AddressResponse>.CreateNew().Build();

            //act
            Action action = () => addressResponse.ValidateInstance();

            //assert
            action.Should().NotThrow<ApplicationRequestException>();
        }
    }
}
