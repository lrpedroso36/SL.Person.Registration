using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Domain.Results.Base;
using SL.Person.Registration.Domain.Results.Contrats;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Domain.Results
{
    public class ResultTest
    {
        public static List<object[]> Data = new List<object[]>
        {
            new object[] { Builder<Result<ResultMoq>>.CreateNew().Build(), true, null, new List<string>() },
            new object[] { Builder<Result<ResultMoq>>.CreateNew().Build(), true, " ", new List<string>() },
            new object[] { Builder<Result<ResultMoq>>.CreateNew().Build(), true, "", new List<string>() },
            new object[] { Builder<Result<ResultMoq>>.CreateNew().Build(), false, "teste", new List<string>() { "teste" } },
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_set_properties(IResult<ResultMoq> result, bool sucess, string error, List<string> errors)
        {
            result.AddErrors(error);
            result.Errors.Should().BeEquivalentTo(errors);
            result.IsSuccess.Should().Be(sucess);
        }

        [Fact]
        public void Should_not_add_same_errors()
        {
            var result = Builder<Result<ResultMoq>>.CreateNew().Build();
            result.AddErrors("teste");
            result.AddErrors("teste");

            result.Errors.Should().HaveCount(1);
        }
    }

    public class ResultMoq
    {
        public int Id { get; set; }
    }
}
