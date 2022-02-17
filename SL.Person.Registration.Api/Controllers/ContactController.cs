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
    [Route("api/v1/contact")]
    public class ContactController : BaseController
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Inserir dados do contato de pessoa
        /// </summary>
        /// <param name="documentNumber">Documento da pessoa</param>
        /// <param name="request">Dados do contato da pessoa</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Pessoa cadastrada com sucesso</response>
        /// <response code="400">Informe os dados da pessoa</response>
        /// <response code="409">Dados inválidos para inserir o contato</response>
        /// <returns></returns>
        [HttpPost("{documentNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Result))]
        public async Task<IActionResult> PostAsync([FromBody] ContactRequest request, long documentNumber, CancellationToken cancellationToken)
            => GetActionResult(await _mediator.Send(new ContactCommand(documentNumber, request), cancellationToken));

        /// <summary>
        /// Atualizar os dados do contato da pessoa
        /// </summary>
        /// <param name="documentNumber">Documento da pessoa</param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Pessoa atualizada com sucesso</response>
        /// <response code="400">Informe os dados da pessoa</response>
        /// <response code="404">Pessoa não encontrada</response>
        /// <response code="409">Dados inválidos para atualizar o contato</response>
        /// <returns></returns>
        [HttpPut("{documnetNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Result))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Result))]
        public async Task<IActionResult> PutAsync([FromBody] ContactRequest request, long documentNumber, CancellationToken cancellationToken)
            => GetActionResult(await _mediator.Send(new ContactCommand(documentNumber, request), cancellationToken));
    }
}
