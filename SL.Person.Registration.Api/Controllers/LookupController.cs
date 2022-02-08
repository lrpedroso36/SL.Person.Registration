using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SL.Person.Registration.Application.Query;
using SL.Person.Registration.Domain.InterViewAggregate.Enuns;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.Domain.Results;
using System.Threading.Tasks;

namespace SL.Person.Registration.Controllers
{
    [ApiController]
    [Route("api/v1/lookup")]
    public class LookupController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LookupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obter lista de tipo de entrevistas
        /// </summary>
        /// <returns>l</returns>
        [HttpGet("interview")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FindLookupResult))]
        public async Task<IActionResult> GetInterviewTypeAsync()
        {
            var result = await _mediator.Send(new FindLookupQuery(typeof(InterviewType)));
            return Ok(result);
        }

        /// <summary>
        /// Lista de tipos de tratamentos
        /// </summary>
        /// <returns></returns>
        [HttpGet("treatment")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FindLookupResult))]
        public async Task<IActionResult> GetTreatmentTypeAsync()
        {
            var result = await _mediator.Send(new FindLookupQuery(typeof(TreatmentType)));
            return Ok(result);
        }

        /// <summary>
        /// Lista de tipos de pessoas
        /// </summary>
        /// <returns></returns>
        [HttpGet("person")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FindLookupResult))]
        public async Task<IActionResult> GetPersonTypeAsync()
        {
            var result = await _mediator.Send(new FindLookupQuery(typeof(PersonType)));
            return Ok(result);
        }

        /// <summary>
        /// Lista de tipos de genero
        /// </summary>
        /// <returns></returns>
        [HttpGet("gender")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FindLookupResult))]
        public async Task<IActionResult> GetGenderTypeAsync()
        {
            var result = await _mediator.Send(new FindLookupQuery(typeof(GenderType)));
            return Ok(result);
        }
    }
}
