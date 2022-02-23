﻿using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Application.Query;
using SL.Person.Registration.Application.Query.Handler;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Results.Base;
using SL.Person.Registration.Domain.Results.Enums;
using SL.Person.Registration.UnitTests.MoqUnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query.Handler
{
    public class FindPersonByNameQueryHandlerTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[]
            {
                new FindPersonByNameQuery("teste"),
                GetPersonRegistration(),
                true,
                new List<string>(),
                (ErrorType)0
            }
        };

        public static IEnumerable<PersonRegistration> GetPersonRegistration()
        {
            var person = Builder<PersonRegistration>.CreateListOfSize(1).Build();
            foreach (var item in person)
            {
                item.AddAdress(Builder<Address>.CreateNew().Build());
                item.AddContact(Builder<Contact>.CreateNew().Build());
                yield return item;
            }
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async Task Should_execute_handler(FindPersonByNameQuery query, IEnumerable<PersonRegistration> registration,
            bool isSucess, List<string> errors, ErrorType errorType)
        {
            //arrange
            var moqRepository = MockPersonRegistrationRepository.GetMockRepository(registration?.FirstOrDefault());

            //act
            var resultHandler = new FindPersonByNameQueryHandler(moqRepository.Object);
            var handler = await resultHandler.Handle(query, default);

            //assert
            handler.IsSuccess.Should().Be(isSucess);
            handler.Errors.Should().BeEquivalentTo(errors);
            handler.ErrorType.Should().Be(errorType);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public async Task Should_execute_handler_invalid_request(string name)
        {
            //arrange
            var queryHandler = new FindPersonByNameQueryHandler(null);

            //act
            Func<Task<ResultBase>> action = async () => await queryHandler.Handle(new FindPersonByNameQuery(name), default);

            //assert
            await action.Should().ThrowAsync<ApplicationRequestException>();
        }

        [Fact]
        public async Task Should_execute_handler_person_not_found()
        {
            //arrange
            var moq = MockPersonRegistrationRepository.GetMockRepository(null);
            var queryHandler = new FindPersonByNameQueryHandler(moq.Object);

            //act
            Func<Task<ResultBase>> action = async () => await queryHandler.Handle(new FindPersonByNameQuery("name"), default);

            //assert
            await action.Should().ThrowAsync<ApplicationRequestException>();
        }
    }
}
