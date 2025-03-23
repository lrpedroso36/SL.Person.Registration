using FizzWare.NBuilder;
using Moq;
using SL.Person.Registration.Application.Command.Person.Update;
using SL.Person.Registration.Application.Commons.Requests;
using SL.Person.Registration.Domain.PersonAggregate;
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
            mockRepository.Verify(x => x.GetByDocumentASync(It.IsAny<long>(), default), Times.AtMost(atMostGet));
            mockRepository.Verify(x => x.UpdateAsync(It.IsAny<PersonRegistration>(), default), Times.AtMost(atMostUpdate));
        }
    }
}
