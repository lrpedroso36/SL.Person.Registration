using FluentAssertions;
using SL.Person.Registratio.CrossCuting.Resources;
using SL.Person.Registration.Application.Query;
using SL.Person.Registration.Application.Query.Validations;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;
using System.Collections.Generic;
using Xunit;

namespace SL.Person.Registration.UnitTests.Application.Query.Validations
{
    public class FindPersonByDocumentQueryValidationTest
    {
        public static List<object[]> Data = new List<object[]>
        {
            new object[] { new FindPersonByDocumentQuery(0),
                           GetResult(ResourceMessagesValidation.FindPersonByDocumentQueryValidation_RequestInvalid, ErrorType.InvalidParameters)
            },
            new object[] { new FindPersonByDocumentQuery(1),
                           GetResult(string.Empty, 0)
            }
        };

        public static ResultEntities<FindPersonResult> GetResult(string errors, ErrorType errorType)
        {
            var result = new ResultEntities<FindPersonResult>();
            result.AddErrors(errors, errorType);
            return result;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_request_validate(FindPersonByDocumentQuery request, ResultEntities<FindPersonResult> resultExpected)
        {
            //arrange
            //act
            var result = request.RequestValidate();

            //assert
            result.Should().BeEquivalentTo(resultExpected);
        }
    }
}
