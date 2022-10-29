using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SL.Person.Registration.Application.Command.PresenceAssignment;
using SL.Person.Registration.Application.Commons.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Api.Controllers;

[ApiController]
[Route("api/v1/assignment")]
public class AssignmentController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssignmentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Inserir a precença do tarefeiro
    /// </summary>
    /// <param name="id">'Id' da pessoa</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Precença inserida com sucesso</response>
    /// <response code="400">Informe o 'Id' do terefeiro</response>
    /// <response code="404">Tarefeiro não econtrado</response>
    /// <returns></returns>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Result))]
    public async Task PutAsync(string id, CancellationToken cancellationToken)
        => await _mediator.Send(new PresenceAssignmentCommand(id), cancellationToken);
}
