using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SL.Person.Registration.Application.Query;
using SL.Person.Registration.Domain.DonationAggregate.Enuns;
using SL.Person.Registration.Domain.InterViewAggregate.Enuns;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.Domain.Results;

namespace SL.Person.Registration.Controllers
{
    [ApiController]
    [Route("api/v1/lookups")]
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
        /// Lista de tipos de doação
        /// </summary>
        /// <returns></returns>
        [HttpGet("donation")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FindLookupResult))]
        public async Task<IActionResult> GetDonationTypeAsync()
        {
            var result = await _mediator.Send(new FindLookupQuery(typeof(DonationType)));
            return Ok(result);
        }

        /// <summary>
        /// Lista de tipos de doação recebida
        /// </summary>
        /// <returns></returns>
        [HttpGet("receive")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FindLookupResult))]
        public async Task<IActionResult> GetReceiveTypeAsync()
        {
            var result = await _mediator.Send(new FindLookupQuery(typeof(ReceiveType)));
            return Ok(result);
        }
    }
}
