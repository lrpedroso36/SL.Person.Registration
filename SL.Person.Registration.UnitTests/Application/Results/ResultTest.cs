using FluentAssertions;
using SL.Person.Registration.Application.Results;
using SL.Person.Registration.Application.Results.Enums;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Results
{
    public class ResultTest
    {
        [Fact]
        public void Should_resul_is_sucess()
        {
            //arrange
            //act
            var result = new Result();

            //assert
            result.IsSuccess.Should().BeTrue();
            result.Errors.Should().HaveCount(0);
            result.ErrorType.Should().Be((ErrorType)0);
        }

        [Theory]
        [InlineData("error", ErrorType.InvalidParameters)]
        [InlineData("error", ErrorType.EntitiesProperty)]
        [InlineData("error", ErrorType.NotFoundData)]
        public void Should_resul_is_not_sucess(string error, ErrorType errorType)
        {
            //arrange
            var errorsExpected = new List<string>() { error };

            //act
            var result = new Result();
            result.SetErrorType(errorType);
            result.AddErrors(error);

            //assert
            result.IsSuccess.Should().BeFalse();
            result.Errors.Should().BeEquivalentTo(errorsExpected);
            result.ErrorType.Should().Be(errorType);
        }

        [Fact]
        public void Should_not_add_same_errors()
        {
            //arrage
            //act
            var result = new Result();
            result.SetErrorType(ErrorType.InvalidParameters);
            result.AddErrors("teste");
            result.AddErrors("teste");

            //assert
            result.Errors.Should().HaveCount(1);
        }
    }
}
