using Moq;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Repositories;

namespace SL.Person.Registration.UnitTests.MoqUnitTest
{
    public class MockInformatioRegistrationRepository
    {
        public static Mock<IPersonRepository> GetMockRepository(PersonRegistration resultSetup)
        {
            var moq = new Mock<IPersonRepository>();
            moq.Setup(x => x.GetByDocument(It.IsAny<long>())).Returns(resultSetup);

            return moq;
        }
    }
}
