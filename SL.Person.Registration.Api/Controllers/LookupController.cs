using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SL.Person.Registration.Application.Query.FindLookup;
using SL.Person.Registration.Application.Query.FindLookup.Responses;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using System.Threading.Tasks;

namespace SL.Person.Registration.Api.Controllers;

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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FindLookupResponse))]
    public async Task<IActionResult> GetInterviewTypeAsync()
        => Ok(await _mediator.Send(new FindLookupQuery(typeof(InterviewType))));

    /// <summary>
    /// Lista de tipos de tratamentos
    /// </summary>
    /// <returns></returns>
    [HttpGet("treatment")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FindLookupResponse))]
    public async Task<IActionResult> GetTreatmentTypeAsync()
        => Ok(await _mediator.Send(new FindLookupQuery(typeof(TreatmentType))));

    /// <summary>
    /// Lista de tipos de pessoas
    /// </summary>
    /// <returns></returns>
    [HttpGet("person")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FindLookupResponse))]
    public async Task<IActionResult> GetPersonTypeAsync()
        => Ok();
    //TODO=> Ok(await _mediator.Send(new FindLookupQuery(typeof(PersonType))));

    /// <summary>
    /// Lista de tipos de genero
    /// </summary>
    /// <returns></returns>
    [HttpGet("gender")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FindLookupResponse))]
    public async Task<IActionResult> GetGenderTypeAsync()
        => Ok(await _mediator.Send(new FindLookupQuery(typeof(GenderType))));

    /// <summary>
    /// Dia da semana
    /// </summary>
    /// <returns></returns>
    [HttpGet("weakDay")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FindLookupResponse))]
    public async Task<IActionResult> GetWeakDay()
        => Ok(await _mediator.Send(new FindLookupQuery(typeof(WeakDayType))));
}
