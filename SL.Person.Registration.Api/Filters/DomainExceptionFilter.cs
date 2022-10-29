using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SL.Person.Registration.Application.Commons.Exceptions;
using SL.Person.Registration.Application.Commons.Responses.Base;
using SL.Person.Registration.Application.Commons.Responses.Enums;
using System.Net;

namespace SL.Person.Registration.Api.Filters;

public class DomainExceptionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context) { }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception is DomainException domainException)
        {
            context.Result = new ObjectResult(domainException.Result)
            {
                StatusCode = GetStatusCode(domainException.Result)
            };
        };

        context.ExceptionHandled = true;
    }

    private int? GetStatusCode(ResultBase result)
    {
        if (!result.IsSuccess && result.ErrorType == ErrorType.EntitiesProperty)
            return (int)HttpStatusCode.Conflict;

        return (int)HttpStatusCode.OK;
    }
}
