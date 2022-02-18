using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Command.Handler;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Domain.Requests;
using SL.Person.Registration.Domain.Results.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Handler
{
    public class InsertInterviewCommandHandlerTest
    {
        public static List<object[]> Data = new List<object[]>
        {
            new object[] { new InsertInterviewCommand(Builder<InterviewRequest>.CreateNew().Build()),
                           2,
                           Builder<PersonRegistration>.CreateNew().Build(),
                           PersonRegistration.CreateInstance(Guid.NewGuid(), new List<PersonType>() { PersonType.Entrevistador }, "nome", 123456789)
            }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public async Task Should_execute_handler(InsertInterviewCommand command, int atMostInsert,
            PersonRegistration personRegistration, PersonRegistration personInterview)
        {
            //arrange
            var moq = new Mock<IPersonRegistrationRepository>();
            moq.Setup(x => x.GetByDocument(It.IsAny<long>())).Returns(personRegistration);
            moq.Setup(x => x.GetByDocument(It.IsAny<long>(), It.IsAny<PersonType>())).Returns(personInterview);

            //act
            var commandHandler = new InsertInterviewCommandHandler(moq.Object);
            var result = await commandHandler.Handle(command, default);

            //assert
            moq.Verify(x => x.Insert(It.IsAny<PersonRegistration>()), Times.AtMost(atMostInsert));
        }
    }
}
