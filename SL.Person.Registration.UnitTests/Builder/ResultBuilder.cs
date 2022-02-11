using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.UnitTests.Builder
{
    public static class ResultBuilder
    {
        public static Result<T> GetResult<T>(string error, ErrorType errorType)
        {
            var result = new Result<T>();
            result.AddErrors(error, errorType);
            return result;
        }
    }
}
