using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Application.Query.Validations
{
    public static class FindPersonByContactNumberQueryValidation
    {
        public static Result<FindPersonResult> RequestValidate(this FindPersonByContactNumberQuery request)
        {
            var result = new Result<FindPersonResult>();

            if (request.Ddd == 0 || request.PhoneNumber == 0)
            {
                result.AddErrors("Informe o número do DDD e Celular.", ErrorType.InvalidParameters);
                return result;
            }

            return result;
        }
    }
}
