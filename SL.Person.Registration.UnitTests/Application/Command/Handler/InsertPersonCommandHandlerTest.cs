using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Command.Hanler;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Requests;
using SL.Person.Registration.Domain.Results.Enums;
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
            new object[] { new InsertPersonCommand(null),
                           false,
                           0,
                           new List<string>() { ResourceMessagesValidation.InsertPersonCommandValidation_RequestInvalid }, ErrorType.InvalidParameters
            },
            new object[] { new InsertPersonCommand(GetPerson()),
                           false,
                           0,
                           new List<string>() { ResourceMessagesValidation.InsertPersonCommandValidation_RequestInvalid }, ErrorType.InvalidParameters
            },
            new object[] { new InsertPersonCommand(Builder<PersonRequest>.CreateNew().Build()),
                           true,
                           1,
                           new List<string>(),
                           (ErrorType)0
            }
        };

        private static PersonRequest GetPerson()
        {
            var result = new PersonRequest();
            result.DocumentNumber = 0;
            return result;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async Task Should_execute_handler(InsertPersonCommand command, bool resultCommand, int atMostInsert,
            List<string> errors, ErrorType errorType)
        {
            //arrange
            var mockRepository = MockPersonRegistrationRepository.GetMockRepository(null);

            //act
            var commandHandler = new InsertPersonCommandHandler(mockRepository.Object);
            var result = await commandHandler.Handle(command, default);

            //assert
            mockRepository.Verify(x => x.Insert(It.IsAny<PersonRegistration>()), Times.AtMost(atMostInsert));
            result.IsSuccess.Should().Be(resultCommand);
            result.Data.Should().Be(resultCommand);
            result.Errors.Should().BeEquivalentTo(errors);
            result.ErrorType.Should().Be(errorType);
        }
    }
}
