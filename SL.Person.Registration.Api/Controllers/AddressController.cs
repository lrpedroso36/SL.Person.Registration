using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SL.Person.Registration.Application.Commons.Responses.Base;
using SL.Person.Registration.Application.Query.FindAddressByZipCode;
using System.Threading;
using System.Threading.Tasks;


namespace SL.Person.Registration.Api.Controllers;

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
    /// Obter o endereço por cep
    /// </summary>
    /// <param name="zipCode">CEP para realizar a busca</param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Retorna os dados do endereço</response>
    /// <response code="400">CEP informado está inválido</response>
    /// <response code="404">Não foi possível encontrar o endereço</response>
    /// <returns></returns>
    [HttpGet("{zipCode}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseBase))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseBase))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseBase))]
    public async Task<ResponseBase> GetAsync(string zipCode, CancellationToken cancellationToken)
        => await _mediator.Send(new FindAddressByZipCodeQuery(zipCode), cancellationToken);
}
