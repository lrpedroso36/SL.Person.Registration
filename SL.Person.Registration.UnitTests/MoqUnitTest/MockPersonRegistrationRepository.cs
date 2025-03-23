using Moq;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace SL.Person.Registration.UnitTests.MoqUnitTest
{
    public class MockPersonRegistrationRepository
    {
        public static Mock<IPersonRegistrationRepository> GetMockRepository(PersonRegistration resultSetup)
        {
            var moq = new Mock<IPersonRegistrationRepository>();
            moq.Setup(x => x.GetByIdAsync(It.IsAny<string>(), default)).ReturnsAsync(resultSetup);
            moq.Setup(x => x.GetByDocumentASync(It.IsAny<long>(), default)).ReturnsAsync(resultSetup);
            moq.Setup(x => x.GetByDocumentAsync(It.IsAny<long>(), It.IsAny<Guid>(), default)).ReturnsAsync(resultSetup);
            MoqGetByName(moq, resultSetup);
            return moq;
        }

        private static void MoqGetByName(Mock<IPersonRegistrationRepository> moq, PersonRegistration resultSetup)
        {
            if (resultSetup == null)
            {
                List<PersonRegistration> listNull = null;
                moq.Setup(x => x.GetByNameAsync(It.IsAny<string>(), default)).ReturnsAsync(listNull);
                moq.Setup(x => x.GetAsync(It.IsAny<Guid?>(), It.IsAny<string>(), It.IsAny<long>(), default)).ReturnsAsync(listNull);
            }
            else
            {
                moq.Setup(x => x.GetByNameAsync(It.IsAny<string>(), default)).ReturnsAsync(new List<PersonRegistration> { resultSetup });
                moq.Setup(x => x.GetAsync(It.IsAny<Guid?>(), It.IsAny<string>(), It.IsAny<long>(), default)).ReturnsAsync(new List<PersonRegistration> { resultSetup });
            }
        }
    }
}
