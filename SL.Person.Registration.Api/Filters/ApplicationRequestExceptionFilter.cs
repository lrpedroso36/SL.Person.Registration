using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Domain.Results.Base;
using SL.Person.Registration.Domain.Results.Enums;
using System.Net;

namespace SL.Person.Registration.Api.Filters
{
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
            };

            context.ExceptionHandled = true;
        }

        private int? GetStatusCode(ResultBase result)
        {
            if (!result.IsSuccess && result.ErrorType == ErrorType.InvalidParameters)
                return (int)HttpStatusCode.BadRequest;

            if (!result.IsSuccess && result.ErrorType == ErrorType.NotFoundData)
                return (int)HttpStatusCode.NotFound;

            if (!result.IsSuccess && result.ErrorType == ErrorType.Found)
                return (int)HttpStatusCode.Conflict;

            return (int)HttpStatusCode.OK;
        }
    }
}
