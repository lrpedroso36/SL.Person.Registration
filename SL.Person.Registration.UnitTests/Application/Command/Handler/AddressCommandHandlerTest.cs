using FizzWare.NBuilder;
using FluentAssertions;
using MediatR;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Command.Handler;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Requests;
using SL.Person.Registration.UnitTests.MoqUnitTest;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Handler
{
    public class AddressCommandHandlerTest
    {
        public static List<object[]> Data = new List<object[]>
        {
            new object[] { new AddressCommand(123456789, Builder<AddressRequest>.CreateNew().Build()),
                           Builder<PersonRegistration>.CreateNew().Build(),
                           Unit.Value
            }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public async Task Should_execute_handler(AddressCommand command, PersonRegistration personRegistration, Unit resultExpected)
        {
            //arrange
            var moq = MockPersonRegistrationRepository.GetMockRepository(personRegistration);

            //act
            var commandHandler = new AddressCommandHandler(moq.Object);
            var result = await commandHandler.Handle(command, default);

            //assert
            result.Should().BeEquivalentTo(resultExpected);
        }
    }
}
