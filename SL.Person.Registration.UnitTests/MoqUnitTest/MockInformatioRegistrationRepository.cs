using Moq;
using SL.Person.Registration.Domain.RegistrationAggregate;
using SL.Person.Registration.Domain.Repositories;

namespace SL.Person.Registration.UnitTests.MoqUnitTest
{
    public class MockInformatioRegistrationRepository
    {
        public static Mock<IInformationRegistrationRepository> GetMockRepository(InformationRegistration resultSetup)
        {
            var moq = new Mock<IInformationRegistrationRepository>();
            moq.Setup(x => x.GetByDocument(It.IsAny<long>())).Returns(resultSetup);

            return moq;
        }
    }
}
