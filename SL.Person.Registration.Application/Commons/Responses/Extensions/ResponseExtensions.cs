using FluentValidation.Results;
using SL.Person.Registration.Application.Commons.Responses.Enums;

namespace SL.Person.Registration.Application.Commons.Responses.Extensions;

public static class ResponseExtensions
{
    public static Response ToInvalidParameter(this Response result, string message)
        => result.SetError(ErrorType.Found, message);

    public static Response ToNotFound(this Response result, string message)
        => result.SetError(ErrorType.Found, message);

    public static Response ToFound(this Response result, string message)
        => result.SetError(ErrorType.Found, message);

    public static Response ToEntitiesProperty(this Response result, ValidationResult validationResult)
    {
        result.SetErrorType(ErrorType.EntitiesProperty);
        validationResult.Errors.ForEach(error => result.AddErrors(error.ErrorMessage));
        return result;
    }

    private static Response SetError(this Response result, ErrorType errorType, string message)
    {
        result.SetErrorType(errorType);
        result.AddErrors(message);
        return result;
    }
}
