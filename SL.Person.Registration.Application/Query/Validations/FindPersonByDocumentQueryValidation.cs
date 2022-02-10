using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Application.Query.Validations
{
    public static class FindPersonByDocumentQueryValidation
    {
        public static Result<FindPersonResult> RequestValidate(this FindPersonByDocumentQuery request)
        {
            var result = new Result<FindPersonResult>();

            if (request.DocumentNumber == 0)
            {
                result.AddErrors("Informe o número do Documento.", ErrorType.InvalidParameters);
                return result;
            }

            return result;
        }
    }
}
