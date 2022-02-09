﻿using FizzWare.NBuilder;
using FluentAssertions;
using SL.Person.Registration.Application.Query;
using SL.Person.Registration.Application.Query.Handler;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.UnitTests.MoqUnitTest;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query.Handler
{
    public class FindPersonByDocumentQueryHandlerTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[] {
                new FindPersonByDocumentQuery(0),
                null,
                null,
                false,
                new List<string>() { "Informe o número do Documento." }
            },
             new object[] {
                new FindPersonByDocumentQuery(1),
                null,
                null,
                false,
                new List<string>() { "Pessoa não encontrada." }
            },
            new object[]
            {
                new FindPersonByDocumentQuery(123456789),
                Builder<FindPersonResult>.CreateNew().Build(),
                GetPersonRegistration(),
                true,
                new List<string>()
            }
        };

        public static PersonRegistration GetPersonRegistration()
        {
            var person = Builder<PersonRegistration>.CreateNew().Build();
            person.AddAdress(Builder<Address>.CreateNew().Build());
            person.AddContact(Builder<Contact>.CreateNew().Build());
            return person;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async Task Should_execute_handler(FindPersonByDocumentQuery query, FindPersonResult result,
            PersonRegistration registration, bool isSucess, List<string> errors)
        {
            var moqRepository = MockInformatioRegistrationRepository.GetMockRepository(registration);

            var resultHandler = new FindPersonByDocumentQueryHandler(moqRepository.Object);

            var handler = await resultHandler.Handle(query, default);
            handler.Data.Should().BeEquivalentTo(result);
            handler.IsSuccess.Should().Be(isSucess);
            handler.Errors.Should().BeEquivalentTo(errors);
        }
    }
}
