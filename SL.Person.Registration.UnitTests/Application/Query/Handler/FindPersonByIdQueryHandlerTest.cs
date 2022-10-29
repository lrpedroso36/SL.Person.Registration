using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Application.Commons.Exceptions;
using SL.Person.Registration.Application.Commons.Responses.Base;
using SL.Person.Registration.Application.Commons.Responses.Enums;
using SL.Person.Registration.Application.Query.FindPersonById;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.UnitTests.MoqUnitTest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query.Handler;

public class FindPersonByIdQueryHandlerTest
{
    public static PersonRegistration GetPersonRegistration()
    {
        var person = Builder<PersonRegistration>.CreateNew().Build();
        person.AddAdress(Builder<Address>.CreateNew().Build());
        person.AddContact(Builder<Contact>.CreateNew().Build());
        return person;
    }

    [Fact]
    public async Task Should_execute_handler()
    {
        //arrange
        var query = new FindPersonByIdQuery(Guid.NewGuid().ToString());
        var registration = GetPersonRegistration();
        var isSucess = true;
        var errors = new List<string>();
        var errorType = (ErrorType)0;

        var moqRepository = MockPersonRegistrationRepository.GetMockRepository(registration);

        //act
        var resultHandler = new FindPersonByIdQueryHandler(moqRepository.Object);
        var handler = await resultHandler.Handle(query, default);

        //assert
        handler.IsSuccess.Should().Be(isSucess);
        handler.Errors.Should().BeEquivalentTo(errors);
        handler.ErrorType.Should().Be(errorType);
    }

    [Theory]
    [InlineData(" ")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("asdas")]
    public async Task Should_execute_handler_invalid_request(string id)
    {
        //arrange
        var queryHandler = new FindPersonByIdQueryHandler(null);

        //act
        Func<Task<ResponseBase>> action = async () => await queryHandler.Handle(new FindPersonByIdQuery(id), default);

        //assert
        await action.Should().ThrowAsync<ApplicationRequestException>();
    }

    [Fact]
    public async Task Should_execute_handler_person_not_found()
    {
        //arrange
        var moq = MockPersonRegistrationRepository.GetMockRepository(null);
        var queryHandler = new FindPersonByIdQueryHandler(moq.Object);

        //act
        Func<Task<ResponseBase>> action = async () => await queryHandler.Handle(new FindPersonByIdQuery(Guid.NewGuid().ToString()), default);

        //assert
        await action.Should().ThrowAsync<ApplicationRequestException>();
    }
}
