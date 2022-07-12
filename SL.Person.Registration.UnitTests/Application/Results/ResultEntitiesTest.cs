using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Application.Results;
using SL.Person.Registration.Application.Results.Enums;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Results
{
    public class ResultEntitiesTest
    {
        public static List<object[]> Data = new List<object[]>
        {
            new object[] { Builder<ResultEntities<ResultMoq>>.CreateNew().Build(), true, null, new List<string>() },
            new object[] { Builder<ResultEntities<ResultMoq>>.CreateNew().Build(), true, " ", new List<string>() },
            new object[] { Builder<ResultEntities<ResultMoq>>.CreateNew().Build(), true, "", new List<string>() },
            new object[] { Builder<ResultEntities<ResultMoq>>.CreateNew().Build(), false, "teste", new List<string>() { "teste" } },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_set_properties(ResultEntities<ResultMoq> result, bool sucess, string error, List<string> errors)
        {
            //arrange
            //act
            result.SetErrorType(ErrorType.InvalidParameters);
            result.AddErrors(error);

            //assert
            result.Errors.Should().BeEquivalentTo(errors);
            result.IsSuccess.Should().Be(sucess);
        }

        [Fact]
        public void Should_not_add_same_errors()
        {
            //arrage
            var result = Builder<ResultEntities<ResultMoq>>.CreateNew().Build();

            //act
            result.SetErrorType(ErrorType.InvalidParameters);
            result.AddErrors("teste");
            result.AddErrors("teste");

            //assert
            result.Errors.Should().HaveCount(1);
        }
    }

    public class ResultMoq
    {
        public int Id { get; set; }
    }
}
