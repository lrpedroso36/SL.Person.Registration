using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Domain.Requests;
using SL.Person.Registration.Domain.Results;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Api.Controllers
{
    [ApiController]
    [Route("api/v1/interview")]
    public class InterviewController : BaseController
    {
        private readonly IMediator _mediator;

        public InterviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Inserir entrevista
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Pessoa atualizada com sucesso</response>
        /// <response code="400">Informe os dados da pessoa</response>
        /// <response code="404">Pessoa não encontrada</response>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result<bool>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Result<bool>))]
        public async Task<IActionResult> PostAsync([FromBody] InterviewRequest request, CancellationToken cancellationToken)
            => GetActionResult(await _mediator.Send(new InsertInterviewCommand(request), cancellationToken));

        /// <summary>
        /// Inserir a presenca no tratamento
        /// </summary>
        /// <param name="interviewedDocument">Número do documento do entrevistado</param>
        /// <param name="laborerDocument">Número do documento do tarefeiro</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Pessoa atualizada com sucesso</response>
        /// <response code="400">Informe os dados da pessoa</response>
        /// <response code="404">Pessoa não encontrada</response>
        /// <returns></returns>
        [HttpPost("presence/{interviewedDocument}/{laborerDocument}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result<bool>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Result<bool>))]
        public async Task<IActionResult> PresenceAsync(long interviewedDocument, long laborerDocument, CancellationToken cancellationToken)
            => GetActionResult(await _mediator.Send(new PrecenceCommand(interviewedDocument, laborerDocument), cancellationToken));
    }
}
