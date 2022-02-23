using FizzWare.NBuilder;
using FluentAssertions;
using MediatR;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Command.Handler;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Requests;
using SL.Person.Registration.UnitTests.MoqUnitTest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Handler
{
    public class ContactCommandHandlerTest
    {
        public static List<object[]> Data = new List<object[]>
        {
            new object[] { new ContactCommand(123456789, Builder<ContactRequest>.CreateNew().Build()),
                           Builder<PersonRegistration>.CreateNew().Build(),
                           Unit.Value,
            }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public async Task Should_execute_handler(ContactCommand command, PersonRegistration personRegistration, Unit resultExpected)
        {
            //arrange
            var moq = MockPersonRegistrationRepository.GetMockRepository(personRegistration);

            //act
            var commandHandler = new ContactCommandHandler(moq.Object);
            var result = await commandHandler.Handle(command, default);

            //assert
            result.Should().BeEquivalentTo(resultExpected);
        }

        public static List<object[]> DataInvalid = new List<object[]>()
        {
            new object[] { new ContactCommand(0, new ContactRequest()) },
            new object[] { new ContactCommand(123456789, null) }
        };

        [Theory]
        [MemberData(nameof(DataInvalid))]
        public async Task Should_execute_handler_invalid_request(ContactCommand command)
        {
            //arrange
            //act
            var commandHandler = new ContactCommandHandler(null);
            Func<Task<Unit>> action = async () => await commandHandler.Handle(command, default);

            //assert
            await action.Should().ThrowAsync<ApplicationRequestException>();
        }

        [Fact]
        public async Task Should_execute_handler_not_found_person()
        {
            //arrange
            var command = new ContactCommand(123456789, Builder<ContactRequest>.CreateNew().Build());
            var moq = MockPersonRegistrationRepository.GetMockRepository(null);

            //act
            var commandHandler = new ContactCommandHandler(moq.Object);
            Func<Task<Unit>> action = async () => await commandHandler.Handle(command, default);

            //assert
            await action.Should().ThrowAsync<ApplicationRequestException>();
        }
    }
}
