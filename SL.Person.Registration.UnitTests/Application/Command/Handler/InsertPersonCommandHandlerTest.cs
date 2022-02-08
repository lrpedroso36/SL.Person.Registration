using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Command.Hanler;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Requests;
using SL.Person.Registration.UnitTests.MoqUnitTest;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Handler
{
    public class InsertPersonCommandHandlerTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[] { new InsertPersonCommand(null), false, 0 },
            new object[] { new InsertPersonCommand(GetPerson()), false, 0 },
            new object[] { new InsertPersonCommand(Builder<PersonRequest>.CreateNew().Build()), true, 1 }
        };

        private static PersonRequest GetPerson()
        {
            var result = new PersonRequest();
            result.DocumentNumber = 0;
            return result;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async Task Should_execute_handler(InsertPersonCommand command, bool resultCommand, int atMostInsert)
        {
            var mockRepository = MockInformatioRegistrationRepository.GetMockRepository(null);

            var commandHandler = new InsertPersonCommandHandler(mockRepository.Object);
            var result = await commandHandler.Handle(command, default);

            mockRepository.Verify(x => x.Insert(It.IsAny<PersonRegistration>()), Times.AtMost(atMostInsert));

            result.Should().Be(resultCommand);
        }
    }
}
