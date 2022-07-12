using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Requests;
using SL.Person.Registration.Application.Results;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Api.Controllers
{
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
        /// <param name="interviewedDocument">Número do documento do entrevistado</param>
        /// <param name="interviewerDocument">Número do documento do entrevistador</param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Entrevista inserida com sucesso</response>
        /// <response code="400">Informe os dados da pessoa</response>
        /// <response code="404">Pessoa não encontrada</response>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Result))]
        public async Task PostAsync(long interviewedDocument, long interviewerDocument, [FromBody] InterviewRequest request, CancellationToken cancellationToken)
            => await _mediator.Send(new InsertInterviewCommand(interviewedDocument, interviewerDocument, request), cancellationToken);

        /// <summary>
        /// Inserir a presença no tratamento
        /// </summary>
        /// <param name="interviewedDocument">Número do documento do entrevistado</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Presença inserida com sucesso</response>
        /// <response code="400">Informe os dados da pessoa</response>
        /// <response code="404">Pessoa não encontrada</response>
        /// <returns></returns>
        [HttpPost("presence/{interviewedDocument}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Result))]
        public async Task PresenceAsync(long interviewedDocument, CancellationToken cancellationToken)
            => await _mediator.Send(new PrecenceCommand(interviewedDocument), cancellationToken);
    }
}
