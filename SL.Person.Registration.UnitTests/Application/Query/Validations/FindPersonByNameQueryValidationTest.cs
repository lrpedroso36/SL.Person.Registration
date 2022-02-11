﻿using FluentAssertions;
using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Query;
using SL.Person.Registration.Application.Query.Validations;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;
using SL.Person.Registration.UnitTests.Builder;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query.Validations
{
    public class FindPersonByNameQueryValidationTest
    {
        public static List<object[]> Data = new List<object[]>
        {
            new object[] { new FindPersonByNameQuery(null),
                           ResultBuilder.GetResult<FindPersonResult>(ResourceMessagesValidation.FindPersonByNameQueryValidation_RequestInvalid, ErrorType.InvalidParameters)
            },
            new object[] { new FindPersonByNameQuery(" "),
                           ResultBuilder.GetResult<FindPersonResult>(ResourceMessagesValidation.FindPersonByNameQueryValidation_RequestInvalid, ErrorType.InvalidParameters)
            },
            new object[] { new FindPersonByNameQuery(""),
                           ResultBuilder.GetResult<FindPersonResult>(ResourceMessagesValidation.FindPersonByNameQueryValidation_RequestInvalid, ErrorType.InvalidParameters)
            },
            new object[] { new FindPersonByNameQuery("teste"),
                           ResultBuilder.GetResult<FindPersonResult>(string.Empty, 0)
            }
        };

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_request_validate(FindPersonByNameQuery request, Result<FindPersonResult> resultExpected)
        {
            //arrange
            //act
            var result = request.RequestValidate();

            //assert
            result.Should().BeEquivalentTo(resultExpected);
        }
    }
}