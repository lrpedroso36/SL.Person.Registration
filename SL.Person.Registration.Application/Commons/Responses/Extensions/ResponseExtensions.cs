using FluentValidation.Results;
using SL.Person.Registration.Application.Commons.Responses.Enums;

namespace SL.Person.Registration.Application.Commons.Responses.Extensions;

public static class ResponseExtensions
{
    public static Response ToInvalidParameter(this Response result, string message)
    {
        result.SetErrorType(ErrorType.InvalidParameters);
        result.AddErrors(message);
        return result;
    }

    public static Response ToNotFound(this Response result, string message)
    {
        result.SetErrorType(ErrorType.NotFoundData);
        result.AddErrors(message);
        return result;
    }

    public static Response ToEntitiesProperty(this Response result, ValidationResult validationResult)
    {
        result.SetErrorType(ErrorType.EntitiesProperty);
        validationResult.Errors.ForEach(error => result.AddErrors(error.ErrorMessage));
        return result;
    }
}
