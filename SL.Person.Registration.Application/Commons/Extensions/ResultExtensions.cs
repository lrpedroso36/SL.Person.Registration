using FluentValidation.Results;
using SL.Person.Registration.Application.Commons.Responses;
using SL.Person.Registration.Application.Commons.Responses.Enums;

namespace SL.Person.Registration.Application.Commons.Extensions;

public static class ResultExtensions
{
    public static Result ToInvalidParameter(this Result result, string message)
    {
        result.SetErrorType(ErrorType.InvalidParameters);
        result.AddErrors(message);
        return result;
    }

    public static Result ToNotFound(this Result result, string message)
    {
        result.SetErrorType(ErrorType.NotFoundData);
        result.AddErrors(message);
        return result;
    }

    public static Result ToEntitiesProperty(this Result result, ValidationResult validationResult)
    {
        result.SetErrorType(ErrorType.EntitiesProperty);
        validationResult.Errors.ForEach(error => result.AddErrors(error.ErrorMessage));
        return result;
    }
}
