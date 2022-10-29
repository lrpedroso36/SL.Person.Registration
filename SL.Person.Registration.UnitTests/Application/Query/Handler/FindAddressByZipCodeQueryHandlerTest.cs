using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using SL.Person.Registration.Application.Commons.Exceptions;
using SL.Person.Registration.Application.Commons.Responses.Base;
using SL.Person.Registration.Application.Query.FindAddressByZipCode;
using SL.Person.Registration.Domain.External.Contracts;
using SL.Person.Registration.Domain.External.Response;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query.Handler;

public class FindAddressByZipCodeQueryHandlerTest
{
    [Fact]
    public async Task Should_execute_handler()
    {
        //arrange
        var mockApi = new Mock<IAddressApi>();
        mockApi.Setup(x => x.GetAddressByZipCode(It.IsAny<string>(), default))
            .ReturnsAsync(Builder<AddressResponse>.CreateNew().Build());

        var queryHandler = new FindAddressByZipCodeQueryHandler(mockApi.Object);

        //act
        var result = await queryHandler.Handle(new FindAddressByZipCodeQuery("123456789"), default);

        //assert
        result.IsSuccess.Should().BeTrue();
        result.Errors.Should().HaveCount(0);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public async Task Should_execute_handler_invalid_request(string zipCode)
    {
        //arrange
        var queryHandler = new FindAddressByZipCodeQueryHandler(null);

        //act
        Func<Task<ResultBase>> action = async () => await queryHandler.Handle(new FindAddressByZipCodeQuery(zipCode), default);

        //assert
        await action.Should().ThrowAsync<ApplicationRequestException>();
    }

    [Fact]
    public async Task Should_execute_handler_invalid_address_response()
    {
        //arragen
        AddressResponse addressResponse = null;

        var moq = new Mock<IAddressApi>();
        moq.Setup(x => x.GetAddressByZipCode(It.IsAny<string>(), default)).ReturnsAsync(addressResponse);

        var queryHandler = new FindAddressByZipCodeQueryHandler(moq.Object);

        //act
        Func<Task<ResultBase>> action = async () => await queryHandler.Handle(new FindAddressByZipCodeQuery("13295478"), default);

        //assert
        await action.Should().ThrowAsync<ApplicationRequestException>();
    }
}
