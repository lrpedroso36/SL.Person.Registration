using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SL.Person.Registration.Application.Command.DeletePerson;
using SL.Person.Registration.Application.Command.Person.Insert;
using SL.Person.Registration.Application.Command.Person.Update;
using SL.Person.Registration.Application.Commons.Requests;
using SL.Person.Registration.Application.Commons.Responses;
using SL.Person.Registration.Application.Commons.Responses.Base;
using SL.Person.Registration.Application.Query.FindPeople;
using SL.Person.Registration.Application.Query.FindPeople.Responses;
using SL.Person.Registration.Application.Query.FindPersonById;
using SL.Person.Registration.Application.Query.FindPersonById.Responses;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SL.Person.Registration.Api.Controllers;

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
    /// Pesquisar registro de pessoa pelo 'Id'
    /// </summary>
    /// <param name="id">id da pessoa</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Pesquisa realizada com sucesso</response>
    /// <response code="400">Informe o 'Id' da pessoa</response>
    /// <response code="404">Pessoa não encontrada</response>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseEntities<FindPersonResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseEntities<FindPersonResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseEntities<FindPersonResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ResponseBase> FindPersonByDocumentAsync(string id, CancellationToken cancellationToken)
        => await _mediator.Send(new FindPersonByIdQuery(id), cancellationToken);

    /// <summary>
    /// Pesquisar uma lista de pessoas pelo o nome, documento ou pelo o tipo de pessoa
    /// </summary>
    /// <param name="name">Nome da pessoa</param>
    /// <param name="documentNumber">Document da pessoa</param>
    /// <param name="personTypeId">Código do tipo da pessoa</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Pesquisa realizada com sucesso</response>
    /// <response code="400">Informe o nome ou o documento da pessoa que deseja pesquisar</response>
    /// <response code="404">Pessoa não encontrada</response>
    /// <returns></returns>
    [HttpGet()]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseEntities<IEnumerable<FindPersonResponse>>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseEntities<IEnumerable<FindPersonResponse>>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseEntities<FindPersonResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ResponseEntities<IEnumerable<FindPeopleResponse>>> FindPeople([FromQuery] string name, long documentNumber, Guid? personTypeId, CancellationToken cancellationToken)
        => await _mediator.Send(new FindPeopleQuery(name, documentNumber, personTypeId), cancellationToken);

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
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Response))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(Response))]
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
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Response))]
    public async Task PutAsync([FromBody] PersonRequest request, CancellationToken cancellationToken)
        => await _mediator.Send(new UpdatePersonCommand(request), cancellationToken);

    /// <summary>
    /// Exclui o registro da pessoa por 'Id'
    /// </summary>
    /// <param name="id">'Id' da pessoa</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Pessoa excluida com sucesso</response>
    /// <response code="400">Informe os dados da pessoa</response>
    /// <response code="404">Pessoa não encontrada</response>
    /// <response code="409">Dados inválidos ao atualizar a pessoa</response>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Response))]
    public async Task DeleteAsync(string id, CancellationToken cancellationToken)
        => await _mediator.Send(new DeletePersonCommand(id), cancellationToken);
}
