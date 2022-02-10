using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Application.Command.Validations
{
    public static class UpdatePersonCommandValidation
    {
        public static Result<bool> RequestValidate(this UpdatePersonCommand request)
        {
            var result = new Result<bool>();

            if (request.Person == null || request.Person.DocumentNumber == 0)
            {
                result.AddErrors("Informe os dados da pessoa.", ErrorType.InvalidParameters);
                return result;
            }

            return result;
        }
    }
}
