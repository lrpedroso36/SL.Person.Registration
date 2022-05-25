using FizzWare.NBuilder;
using Moq;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Command.Handler;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Requests;
using SL.Person.Registration.UnitTests.MoqUnitTest;
using System.Threading.Tasks;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Handler
{
    public class UpdatePersonCommandHandlerTest
    {
        [Fact]
        public async Task Should_execute_handler()
        {
            //arrange
            var command = new UpdatePersonCommand(Builder<PersonRequest>.CreateNew().Build());
            var atMostUpdate = 1;
            var atMostGet = 1;
            var registration = Builder<PersonRegistration>.CreateNew().Build();

            var mockRepository = MockPersonRegistrationRepository.GetMockRepository(registration);

            //act
            var commandHandler = new UpdatePersonCommandHandler(mockRepository.Object);
            var result = await commandHandler.Handle(command, default);

            //assert
            mockRepository.Verify(x => x.GetByDocument(It.IsAny<long>()), Times.AtMost(atMostGet));
            mockRepository.Verify(x => x.Update(It.IsAny<PersonRegistration>()), Times.AtMost(atMostUpdate));
        }
    }
}
