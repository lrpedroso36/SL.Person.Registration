using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Command.Handler;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Requests;
using SL.Person.Registration.Domain.Results.Enums;
using SL.Person.Registration.UnitTests.MoqUnitTest;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Handler
{
    public class UpdatePersonCommandHandlerTest
    {
        public static List<object[]> Data = new List<object[]>()
        {
            new object[] { new UpdatePersonCommand(null), 
                           false, 
                           0, 
                           0, 
                           null, 
                           new List<string>() { ResourceMessagesValidation.UpdatePersonCommandValidation_RequestInvalid } ,ErrorType.InvalidParameters 
            },
            new object[] { new UpdatePersonCommand(GetPerson()), 
                           false, 
                           0, 
                           0, 
                           null, 
                           new List<string>() { ResourceMessagesValidation.UpdatePersonCommandValidation_RequestInvalid }, ErrorType.InvalidParameters  
            },
            new object[] { new UpdatePersonCommand(Builder<PersonRequest>.CreateNew().Build()),
                false,
                0,
                1,
                null,
                new List<string>() { ResourceMessagesValidation.PersonRegistration_InstanceInvalid },
                ErrorType.NotFoundData
            },
            new object[] { new UpdatePersonCommand(Builder<PersonRequest>.CreateNew().Build()),
                true,
                1,
                1,
                Builder<PersonRegistration>.CreateNew().Build(),
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
        public async Task Should_execute_handler(UpdatePersonCommand command, bool resultCommand, int atMostUpdate, int atMostGet,
            PersonRegistration registration, List<string> errors, ErrorType errorType)
        {

            //arrange
            var mockRepository = MockPersonRegistrationRepository.GetMockRepository(registration);

            //act
            var commandHandler = new UpdatePersonCommandHandler(mockRepository.Object);
            var result = await commandHandler.Handle(command, default);

            //assert
            mockRepository.Verify(x => x.GetByDocument(It.IsAny<long>()), Times.AtMost(atMostGet));
            mockRepository.Verify(x => x.Update(It.IsAny<PersonRegistration>()), Times.AtMost(atMostUpdate));

            result.Data.Should().Be(resultCommand);
            result.IsSuccess.Should().Be(resultCommand);
            result.Errors.Should().BeEquivalentTo(errors);
            result.ErrorType.Should().Be(errorType);
        }
    }
}
