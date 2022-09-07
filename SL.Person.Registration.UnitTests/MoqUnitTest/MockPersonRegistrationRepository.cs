using Moq;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
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
            moq.Setup(x => x.GetById(It.IsAny<string>())).Returns(resultSetup);
            moq.Setup(x => x.GetByDocument(It.IsAny<long>())).Returns(resultSetup);
            moq.Setup(x => x.GetByDocument(It.IsAny<long>(), It.IsAny<PersonType>())).Returns(resultSetup);
            MoqGetByName(moq, resultSetup);
            return moq;
        }

        private static void MoqGetByName(Mock<IPersonRegistrationRepository> moq, PersonRegistration resultSetup)
        {
            if (resultSetup == null)
            {
                moq.Setup(x => x.GetByName(It.IsAny<string>())).Returns<IEnumerable<PersonRegistration>>(null);
                moq.Setup(x => x.Get(It.IsAny<PersonType?>(), It.IsAny<string>(), It.IsAny<long>())).Returns<IEnumerable<PersonRegistration>>(null);
            }
            else
            {
                moq.Setup(x => x.GetByName(It.IsAny<string>())).Returns(new List<PersonRegistration> { resultSetup });
                moq.Setup(x => x.Get(It.IsAny<PersonType?>(), It.IsAny<string>(), It.IsAny<long>())).Returns(new List<PersonRegistration> { resultSetup });
            }
        }
    }
}
