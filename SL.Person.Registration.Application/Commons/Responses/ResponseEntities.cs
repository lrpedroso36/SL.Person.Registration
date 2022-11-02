using FluentValidation.Results;
using SL.Person.Registration.Application.Commons.Responses.Base;
using SL.Person.Registration.Application.Commons.Responses.Contrats;

namespace SL.Person.Registration.Application.Commons.Responses;

public class ResponseEntities<T> : ResponseBase, IResponse<T> where T : class
{
    public T Data { get; private set; }

    public void SetData(T data)
    {
        Data = data;
    }

    public void ToInvalidParameter(string message)
    {
        SetErrorType(Enums.ErrorType.InvalidParameters);
        AddErrors(message);
    }

    public void ToEntitiesProperty(ValidationResult validationResult)
    {
        SetErrorType(Enums.ErrorType.EntitiesProperty);
        validationResult.Errors.ForEach(error => AddErrors(error.ErrorMessage));
    }

    public void ToNotFound(ValidationResult validationResult)
    {
        SetErrorType(Enums.ErrorType.NotFoundData);
        validationResult.Errors.ForEach(error => AddErrors(error.ErrorMessage));
    }
}
