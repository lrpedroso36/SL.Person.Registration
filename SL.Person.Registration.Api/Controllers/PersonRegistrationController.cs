using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SL.Person.Registration.Api.Controllers;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Query;
using SL.Person.Registration.Domain.Requests;
using SL.Person.Registration.Domain.Results;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Controllers
{
    [ApiController]
    [Route("api/v1/person")]
    public class PersonController : BaseController
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IMediator _mediator;

        public PersonController(ILogger<PersonController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Pesquisar registro de pessoa pelo o número do documento
        /// </summary>
        /// <param name="documentNumber">Número do documento da pessoa</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Pesquisa realizada com sucesso</response>
        /// <response code="400">Informe o número do Documento</response>
        /// <response code="404">Pessoa não encontrada</response>
        /// <returns></returns>
        [HttpGet("{documentNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<FindPersonResult>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result<FindPersonResult>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Result<FindPersonResult>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> FindPersonByDocumentAsync(long documentNumber, CancellationToken cancellationToken)
            => GetActionResult(await _mediator.Send(new FindPersonByDocumentQuery(documentNumber), cancellationToken));

        /// <summary>
        /// Pesquisar registro de pessoa pelo o número do contato
        /// </summary>
        /// <param name="ddd">DDD do telafone</param>
        /// <param name="phoneNumber">Número do telefone</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Pesquisa realizada com sucesso</response>
        /// <response code="400">Informe o número do DDD e Celular</response>
        /// <response code="404">Pessoa não encontrada</response>
        /// <returns></returns>
        [HttpGet("{ddd}/{phoneNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<FindPersonResult>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result<FindPersonResult>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> FindPersonByContactNumber(int ddd, long phoneNumber, CancellationToken cancellationToken)
            => GetActionResult(await _mediator.Send(new FindPersonByContactNumberQuery(ddd, phoneNumber), cancellationToken));


        /// <summary>
        /// Pesquisar uma lista de pessoas pelo o nome
        /// </summary>
        /// <param name="name">Nome da pessoa</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Pesquisa realizada com sucesso</response>
        /// <response code="400">Informe o nome da pessoa que deseja pesquisar</response>
        /// <response code="404">Pessoa não encontrada</response>
        /// <returns></returns>
        [HttpGet("list/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<IEnumerable<FindPersonResult>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result<IEnumerable<FindPersonResult>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Result<FindPersonResult>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> FindPersonByName(string name, CancellationToken cancellationToken)
            => GetActionResult(await _mediator.Send(new FindPersonByNameQuery(name), cancellationToken));

        /// <summary>
        /// Inserir o registro de uma pessoa
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Pessoa cadastrada com sucesso</response>
        /// <response code="400">Informe os dados da pessoa</response>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result<bool>))]
        public async Task<IActionResult> PostAsync([FromBody] PersonRequest request, CancellationToken cancellationToken)
            => GetActionResult(await _mediator.Send(new InsertPersonCommand(request), cancellationToken));

        /// <summary>
        /// Atualizar o registro de uma pessoa
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Pessoa atualizada com sucesso</response>
        /// <response code="400">Informe os dados da pessoa</response>
        /// <response code="404">Pessoa não encontrada</response>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result<bool>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Result<bool>))]
        public async Task<IActionResult> PutAsync([FromBody] PersonRequest request, CancellationToken cancellationToken)
            => GetActionResult(await _mediator.Send(new UpdatePersonCommand(request), cancellationToken));

        /// <summary>
        /// Inserir dados do contato de pessoa
        /// </summary>
        /// <param name="documentNumber">Documento da pessoa</param>
        /// <param name="request">Dados do contato da pessoa</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Pessoa cadastrada com sucesso</response>
        /// <response code="400">Informe os dados da pessoa</response>
        /// <returns></returns>
        [HttpPost("contact/{documentNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result<bool>))]
        public async Task<IActionResult> PostContactAsync([FromBody] ContactRequest request, long documentNumber, CancellationToken cancellationToken)
            => GetActionResult(await _mediator.Send(new InsertOrUpdateContactCommand(documentNumber, request), cancellationToken));

        /// <summary>
        /// Atualizar os dados do contato da pessoa
        /// </summary>
        /// <param name="documentNumber">Documento da pessoa</param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Pessoa atualizada com sucesso</response>
        /// <response code="400">Informe os dados da pessoa</response>
        /// <response code="404">Pessoa não encontrada</response>
        /// <returns></returns>
        [HttpPut("contact/{documnetNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result<bool>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Result<bool>))]
        public async Task<IActionResult> PutContactAsync([FromBody] ContactRequest request, long documentNumber, CancellationToken cancellationToken)
            => GetActionResult(await _mediator.Send(new InsertOrUpdateContactCommand(documentNumber, request), cancellationToken));


        /// <summary>
        /// Inserir dados do endereço de pessoa
        /// </summary>
        /// <param name="documentNumber">Documento da pessoa</param>
        /// <param name="request">Dados do endereço da pessoa</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Pessoa cadastrada com sucesso</response>
        /// <response code="400">Informe os dados da pessoa</response>
        /// <returns></returns>
        [HttpPost("address/{documentNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result<bool>))]
        public async Task<IActionResult> PostAddressAsync([FromBody] AddressRequest request, long documentNumber, CancellationToken cancellationToken)
            => GetActionResult(await _mediator.Send(new InsertOrUpdateAddressCommand(documentNumber, request), cancellationToken));

        /// <summary>
        /// Atualizar os dados do endereço da pessoa
        /// </summary>
        /// <param name="documentNumber">Documento da pessoa</param>
        /// <param name="request">Data do endereço da pessoa</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Pessoa atualizada com sucesso</response>
        /// <response code="400">Informe os dados da pessoa</response>
        /// <response code="404">Pessoa não encontrada</response>
        /// <returns></returns>
        [HttpPut("address/{documnetNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result<bool>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Result<bool>))]
        public async Task<IActionResult> PutAddressAsync([FromBody] AddressRequest request, long documentNumber, CancellationToken cancellationToken)
            => GetActionResult(await _mediator.Send(new InsertOrUpdateAddressCommand(documentNumber, request), cancellationToken));
    }
}
