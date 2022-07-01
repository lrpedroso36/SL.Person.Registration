using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Query;
using SL.Person.Registration.Domain.PersonAggregate.Enuns;
using SL.Person.Registration.Domain.Requests;
using SL.Person.Registration.Domain.Results;
using SL.Person.Registration.Domain.Results.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Controllers
{
    [ApiController]
    [Route("api/v1/person")]
    public class PersonController : ControllerBase
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultEntities<FindPersonResult>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultEntities<FindPersonResult>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResultEntities<FindPersonResult>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ResultBase> FindPersonByDocumentAsync(long documentNumber, CancellationToken cancellationToken)
            => await _mediator.Send(new FindPersonByDocumentQuery(documentNumber), cancellationToken);

        /// <summary>
        /// Pesquisar uma lista de pessoas pelo o nome ou pelo documento
        /// </summary>
        /// <param name="parameter">Nome da pessoa ou documento</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Pesquisa realizada com sucesso</response>
        /// <response code="400">Informe o nome ou o documento da pessoa que deseja pesquisar</response>
        /// <response code="404">Pessoa não encontrada</response>
        /// <returns></returns>
        [HttpGet("list/{parameter}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultEntities<IEnumerable<FindPersonResult>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultEntities<IEnumerable<FindPersonResult>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResultEntities<FindPersonResult>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ResultEntities<IEnumerable<FindPersonResult>>> FindPeople(string parameter, CancellationToken cancellationToken, [FromQuery] PersonType? personType = null)
            => await _mediator.Send(new FindPeopleQuery(parameter, personType), cancellationToken);

        /// <summary>
        /// Pesquisar uma lista de pessoas pelo tipo de pessoa
        /// </summary>
        /// <param name="personType">Tipo de pessoa</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Pesquisa realizada com sucesso</response>
        /// <response code="400">O tipo de pesso</response>
        /// <response code="404">Pessoa não encontrada</response>
        /// <returns></returns>
        [HttpGet("list-persontype/{personType}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResultEntities<IEnumerable<FindPersonResult>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResultEntities<IEnumerable<FindPersonResult>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResultEntities<FindPersonResult>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ResultEntities<IEnumerable<FindPersonResult>>> FindPeopleType(PersonType personType, CancellationToken cancellationToken)
            => await _mediator.Send(new FindPeopleTypeQuery(personType), cancellationToken);

        /// <summary>
        /// Inserir o registro de uma pessoa
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Pessoa cadastrada com sucesso</response>
        /// <response code="400">Informe os dados da pessoa</response>
        /// <response code="409">Dados inválidos ao atualizar a pessoa</response>
        /// <response code="422">Pessoa já cadadastrada</response>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Result))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(Result))]
        public async Task PostAsync([FromBody] PersonRequest request, CancellationToken cancellationToken)
            => await _mediator.Send(new InsertPersonCommand(request), cancellationToken);

        /// <summary>
        /// Atualizar o registro de uma pessoa
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Pessoa atualizada com sucesso</response>
        /// <response code="400">Informe os dados da pessoa</response>
        /// <response code="404">Pessoa não encontrada</response>
        /// <response code="409">Dados inválidos ao atualizar a pessoa</response>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Result))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Result))]
        public async Task PutAsync([FromBody] PersonRequest request, CancellationToken cancellationToken)
            => await _mediator.Send(new UpdatePersonCommand(request), cancellationToken);

        /// <summary>
        /// Exclui o registro da pessoa
        /// </summary>
        /// <param name="documentNumber"></param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Pessoa excluida com sucesso</response>
        /// <response code="400">Informe os dados da pessoa</response>
        /// <response code="404">Pessoa não encontrada</response>
        /// <response code="409">Dados inválidos ao atualizar a pessoa</response>
        /// <returns></returns>
        [HttpDelete("{documentNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Result))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Result))]
        public async Task DeleteAsync(long documentNumber, CancellationToken cancellationToken)
            => await _mediator.Send(new DeletePersonCommand(documentNumber), cancellationToken);
    }
}
