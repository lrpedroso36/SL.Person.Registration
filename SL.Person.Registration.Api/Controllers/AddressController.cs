using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Query;
using SL.Person.Registration.Domain.Requests;
using SL.Person.Registration.Domain.Results;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Api.Controllers
{
    [ApiController]
    [Route("api/v1/address")]
    public class AddressController : BaseController
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Inserir dados do endereço de pessoa
        /// </summary>
        /// <param name="documentNumber">Documento da pessoa</param>
        /// <param name="request">Dados do endereço da pessoa</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Pessoa cadastrada com sucesso</response>
        /// <response code="400">Informe os dados da pessoa</response>
        /// <response code="409">Dados inválidos para inserir o endereço</response>
        /// <returns></returns>
        [HttpPost("{documentNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result<bool>))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Result<bool>))]
        public async Task<IActionResult> PostAsync([FromBody] AddressRequest request, long documentNumber, CancellationToken cancellationToken)
            => GetActionResult(await _mediator.Send(new AddressCommand(documentNumber, request), cancellationToken));

        /// <summary>
        /// Atualizar os dados do endereço da pessoa
        /// </summary>
        /// <param name="documentNumber">Documento da pessoa</param>
        /// <param name="request">Data do endereço da pessoa</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Pessoa atualizada com sucesso</response>
        /// <response code="400">Informe os dados da pessoa</response>
        /// <response code="404">Pessoa não encontrada</response>
        /// <response code="409">Dados inválidos para inserir o endereço</response>
        /// <returns></returns>
        [HttpPut("{documnetNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result<bool>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Result<bool>))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Result<bool>))]
        public async Task<IActionResult> PutAsync([FromBody] AddressRequest request, long documentNumber, CancellationToken cancellationToken)
            => GetActionResult(await _mediator.Send(new AddressCommand(documentNumber, request), cancellationToken));

        /// <summary>
        /// Obter o endereço por cep
        /// </summary>
        /// <param name="zipCode">CEP para realizar a busca</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Retorna os dados do endereço</response>
        /// <response code="400">Não foi possível encontrar o endereço</response>
        /// <returns></returns>
        [HttpGet("{zipCode}")]
        public async Task<IActionResult> GetAsync(string zipCode, CancellationToken cancellationToken)
            => GetActionResult(await _mediator.Send(new FindAddressByZipCodeQuery(zipCode), cancellationToken));
    }
}
