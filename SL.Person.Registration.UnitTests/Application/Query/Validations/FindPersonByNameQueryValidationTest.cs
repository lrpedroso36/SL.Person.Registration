﻿using FluentAssertions;
using SL.Person.Registration.Application.Commons.Exceptions;
using SL.Person.Registration.Application.Query.FindPeople;
using SL.Person.Registration.Application.Query.FindPeople.Extensions;
using System;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query.Validations;

public class FindPersonByNameQueryValidationTest
{
    [Theory]
    [InlineData(null, 0, null)]
    [InlineData(" ", 0, null)]
    [InlineData("", 0, null)]
    public void Should_request_validate(string name, long documentNumber, Guid? personTypeId)
    {
        //arrange
        var request = new FindPeopleQuery(name, documentNumber, personTypeId);
        //act
        Action action = () => request.RequestValidate();

        //assert
        action.Should().Throw<ApplicationRequestException>();
    }

    [Fact]
    public void Should_request_is_valid_recevied_name()
    {
        //arrange
        var request = new FindPeopleQuery("teste", 0, null);
        //act
        Action action = () => request.RequestValidate();

        //assert
        action.Should().NotThrow<ApplicationRequestException>();
    }

    [Fact]
    public void Should_request_is_valid_recevied_document_number()
    {
        //arrange
        var request = new FindPeopleQuery(null, 123456789, null);
        //act
        Action action = () => request.RequestValidate();

        //assert
        action.Should().NotThrow<ApplicationRequestException>();
    }

    [Fact]
    public void Should_request_is_valid_recevied_person_type()
    {
        //arrange
        var request = new FindPeopleQuery(null, 0, Guid.NewGuid());
        //act
        Action action = () => request.RequestValidate();

        //assert
        action.Should().NotThrow<ApplicationRequestException>();
    }

    [Fact]
    public void Should_request_is_valid_recevied_all_parameter()
    {
        //arrange
        var request = new FindPeopleQuery("teste", 12345789, Guid.NewGuid());
        //act
        Action action = () => request.RequestValidate();

        //assert
        action.Should().NotThrow<ApplicationRequestException>();
    }
}
