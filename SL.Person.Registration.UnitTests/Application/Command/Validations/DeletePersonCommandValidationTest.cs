using FluentAssertions;
using SL.Person.Registration.Application.Command.DeletePerson;
using SL.Person.Registration.Application.Command.DeletePerson.Extensions;
using SL.Person.Registration.Application.Commons.Exceptions;
using System;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Validations;

public class DeletePersonCommandValidationTest
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    [InlineData("asdasdasd")]
    public void Should_request_invalid(string id)
    {
        //arrange
        var request = new DeletePersonCommand(id);

        //act
        Action action = () => request.RequestValidate();

        //assert
        action.Should().Throw<ApplicationRequestException>();
    }

    [Fact]
    public void Should_request_valid()
    {
        //arrange
        var request = new DeletePersonCommand(Guid.NewGuid().ToString());

        //act
        Action action = () => request.RequestValidate();

        //assert
        action.Should().NotThrow<ApplicationRequestException>();
    }
}
