using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SL.Person.Registration.Application.Exceptions;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Api.Filters
{
    public class HttpResquestExceptionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpRequestException requestException)
            {
                context.Result = new ObjectResult(requestException.Result)
                {
                    StatusCode = (int)GetStatusCode(requestException.Result)
                };
            };

            context.ExceptionHandled = true;
        }

        private int? GetStatusCode(ResultBase result)
        {
            if (!result.IsSuccess && result.ErrorType == ErrorType.InvalidParameters)
                return 400;

            if (!result.IsSuccess && result.ErrorType == ErrorType.NotFoundData)
                return 404;

            if (!result.IsSuccess && result.ErrorType == ErrorType.EntitiesProperty)
                return 409;

            return 200;
        }
    }
}
