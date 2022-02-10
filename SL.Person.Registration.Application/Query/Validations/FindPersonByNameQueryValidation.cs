using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;
using System.Collections.Generic;

namespace SL.Person.Registration.Application.Query.Validations
{
    public static class FindPersonByNameQueryValidation
    {
        public static Result<IEnumerable<FindPersonResult>> RequestValidate(this FindPersonByNameQuery request)
        {
            var result = new Result<IEnumerable<FindPersonResult>>();

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                result.AddErrors("Informe o nome da pessoa que deseja pesquisar.", ErrorType.InvalidParameters);
                return result;
            }

            return result;
        }
    }
}
