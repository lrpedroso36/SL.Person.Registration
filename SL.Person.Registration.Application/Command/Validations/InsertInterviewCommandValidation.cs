using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Application.Command.Validations
{
    public static class InsertInterviewCommandValidation
    {
        public static Result<bool> RequestValidate(this InsertInterviewCommand request)
        {
            var result = new Result<bool>();

            if (request.Interview == null)
            {
                result.AddErrors("Informe os dados da entrevista.", ErrorType.InvalidParameters);
                return result;
            }

            if (request.Interview.DocumnetNumber == 0 || request.Interview.DocumentNumberInterview == 0)
            {
                result.AddErrors("Informe o documento do paciente ou o documento do entrevistador.", ErrorType.InvalidParameters);
                return result;
            }

            return result;
        }
    }
}
