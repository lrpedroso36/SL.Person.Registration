using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SL.Person.Registration.Application.Command.InsertInterview;
using SL.Person.Registration.Application.Command.Precence;
using SL.Person.Registration.Application.Commons.Requests;
using SL.Person.Registration.Application.Commons.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Api.Controllers;

[ApiController]
[Route("api/v1/interview")]
public class InterviewController : ControllerBase
{
    private readonly IMediator _mediator;

    public InterviewController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Inserir entrevista
    /// </summary>
    /// <param name="interviewedId">'Id' do entrevistado</param>
    /// <param name="interviewerId">'Id' do entrevistador</param>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Entrevista inserida com sucesso</response>
    /// <response code="400">Informe os dados da pessoa</response>
    /// <response code="404">Pessoa não encontrada</response>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response))]
    public async Task PostAsync(string interviewedId, string interviewerId, [FromBody] InterviewRequest request, CancellationToken cancellationToken)
        => await _mediator.Send(new InsertInterviewCommand(interviewedId, interviewerId, request), cancellationToken);

    /// <summary>
    /// Inserir a presença no tratamento
    /// </summary>
    /// <param name="id">'Id' do entrevistado</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Presença inserida com sucesso</response>
    /// <response code="400">Informe os dados da pessoa</response>
    /// <response code="404">Pessoa não encontrada</response>
    /// <returns></returns>
    [HttpPost("presence/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response))]
    public async Task PresenceAsync(string id, CancellationToken cancellationToken)
        => await _mediator.Send(new PrecenceCommand(id), cancellationToken);
}
