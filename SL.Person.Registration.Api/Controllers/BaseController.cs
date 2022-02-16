using Microsoft.AspNetCore.Mvc;
using SL.Person.Registration.Domain.Results.Contrats;
using SL.Person.Registration.Domain.Results.Enums;

namespace SL.Person.Registration.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult GetActionResult<T>(IResult<T> result)
        {
            if (!result.IsSuccess && result.ErrorType == ErrorType.InvalidParameters)
                return BadRequest(result);

            if (!result.IsSuccess && result.ErrorType == ErrorType.NotFoundData)
                return NotFound(result);

            if (!result.IsSuccess && result.ErrorType == ErrorType.EntitiesProperty)
                return Conflict(result);

            return Ok(result);
        }
    }
}
