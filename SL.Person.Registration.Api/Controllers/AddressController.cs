using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Query;
using SL.Person.Registration.Domain.PersonAggregate;
using SL.Person.Registration.Domain.Requests;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Base;
using System.Threading;
using System.Threading.Tasks;


namespace SL.Person.Registration.Api.Controllers
{
    [ApiController]
    [Route("api/v1/address")]
    public class AddressController : ControllerBase
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
        /// <response code="200">Endereço cadastrado com sucesso</response>
        /// <response code="400">Informe os dados da pessoa</response>
        /// <response code="409">Dados inválidos para inserir o endereço</response>
        /// <returns></returns>
        [HttpPost("{documentNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Result))]
        public async Task PostAsync(long documentNumber, [FromBody] AddressRequest request, CancellationToken cancellationToken)
            => await _mediator.Send(new AddressCommand(documentNumber, request), cancellationToken);

        /// <summary>
        /// Atualizar os dados do endereço da pessoa
        /// </summary>
        /// <param name="documentNumber">Documento da pessoa</param>
        /// <param name="request">Data do endereço da pessoa</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Endereço atualizado com sucesso</response>
        /// <response code="400">Informe os dados da pessoa</response>
        /// <response code="404">Pessoa não encontrada</response>
        /// <response code="409">Dados inválidos para inserir o endereço</response>
        /// <returns></returns>
        [HttpPut("{documentNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Result))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Result))]
        public async Task PutAsync(long documentNumber, [FromBody] AddressRequest request, CancellationToken cancellationToken)
            => await _mediator.Send(new AddressCommand(documentNumber, request), cancellationToken);

        /// <summary>
        /// Obter o endereço por cep
        /// </summary>
        /// <param name="zipCode">CEP para realizar a busca</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Retorna os dados do endereço</response>
        /// <response code="400">CEP informado está inválido</response>
        /// <response code="404">Não foi possível encontrar o endereço</response>
        /// <returns></returns>
        [HttpGet("{zipCode}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultEntities<Address>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultEntities<Address>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResultEntities<Address>))]
        public async Task<ResultBase> GetAsync(string zipCode, CancellationToken cancellationToken)
            => await _mediator.Send(new FindAddressByZipCodeQuery(zipCode), cancellationToken);
    }
}
