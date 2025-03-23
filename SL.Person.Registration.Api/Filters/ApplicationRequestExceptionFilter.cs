using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SL.Person.Registration.Application.Commons.Exceptions;
using SL.Person.Registration.Application.Commons.Responses.Base;
using SL.Person.Registration.Application.Commons.Responses.Enums;
using System.Net;

namespace SL.Person.Registration.Api.Filters;

public class ApplicationRequestExceptionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is ApplicationRequestException requestException)
        {
            context.Result = new ObjectResult(requestException.Result)
            {
                StatusCode = GetStatusCode(requestException.Result)
            };
        }
        ;

        context.ExceptionHandled = true;
    }

    private int? GetStatusCode(ResponseBase result)
    {
        if (!result.IsSuccess && result.ErrorType == ErrorType.InvalidParameters)
            return (int)HttpStatusCode.BadRequest;

        if (!result.IsSuccess && result.ErrorType == ErrorType.NotFoundData)
            return (int)HttpStatusCode.NotFound;

        if (!result.IsSuccess && result.ErrorType == ErrorType.Found)
            return (int)HttpStatusCode.UnprocessableEntity;

        return (int)HttpStatusCode.OK;
    }
}
