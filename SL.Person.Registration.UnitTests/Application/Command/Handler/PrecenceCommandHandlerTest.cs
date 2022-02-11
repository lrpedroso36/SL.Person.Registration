using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Command.Handler;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.Domain.Repositories;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;
using SL.Person.Registration.UnitTests.Builder;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Command.Handler
{
    public class PrecenceCommandHandlerTest
    {
        public static List<object[]> Data = new List<object[]>
        {
            new object[] { new PrecenceCommand(0,1),
                           ResultBuilder.GetResult<bool>(ResourceMessagesValidation.PrecenceCommandValidation_DataRequestInvalid, ErrorType.InvalidParameters),
                           null,
                           null
            },
            new object[] { new PrecenceCommand(1,0),
                           ResultBuilder.GetResult<bool>(ResourceMessagesValidation.PrecenceCommandValidation_DataRequestInvalid, ErrorType.InvalidParameters),
                           null,
                           null
            },
            new object[] { new PrecenceCommand(0,0),
                           ResultBuilder.GetResult<bool>(ResourceMessagesValidation.PrecenceCommandValidation_DataRequestInvalid, ErrorType.InvalidParameters),
                           null,
                           null
            },
            new object[] { new PrecenceCommand(1,1),
                          ResultBuilder.GetResult<bool>(ResourceMessagesValidation.PersonRegistration_InstanceInvalid, ErrorType.NotFoundData),
                          null,
                          null

            },
            new object[] { new PrecenceCommand(1,1),
                           ResultBuilder.GetResult<bool>(ResourceMessagesValidation.PersonRegistration_InstanceInvalid, ErrorType.NotFoundData),
                           PersonRegistration.CreateInstance(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido }, "nome" ,1234567890),
                           null
            },
            new object[] { new PrecenceCommand(1,1),
                           GetResult(),
                           PersonRegistration.CreateInstance(Guid.NewGuid(), new List<PersonType> { PersonType.Assistido }, "nome" ,1234567890),
                           Builder<PersonRegistration>.CreateNew().Build()
            }
        };

        public static Result<bool> GetResult()
        {
            var result = ResultBuilder.GetResult<bool>(string.Empty, 0);
            result.SetData(true);
            return result;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async Task Should_execute_handler_request_validate(PrecenceCommand precenceCommand, Result<bool> resultExpected,
            PersonRegistration personWatched, PersonRegistration personTaskMaster)
        {
            //arrange
            var moq = new Mock<IPersonRegistrationRepository>();
            moq.Setup(x => x.GetByDocument(It.IsAny<long>())).Returns(personTaskMaster);
            moq.Setup(x => x.GetByDocument(It.IsAny<long>(), It.IsAny<PersonType>())).Returns(personWatched);

            //act
            var commandHandler = new PrecenceCommandHandler(moq.Object);
            var result = await commandHandler.Handle(precenceCommand, default);

            //assert
            result.Should().BeEquivalentTo(resultExpected);
        }
    }
}
