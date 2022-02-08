using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Query;
using SL.Person.Registration.Domain.Requests;
using SL.Person.Registration.Domain.Results;
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
        /// <param name="documentNumber"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{documentNumber}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FindPersonResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> FindPersonByDocumentAsync(long documentNumber, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new FindPersonByDocumentQuery(documentNumber), cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Pesquisar registro de pessoa pelo o número do contato
        /// </summary>
        /// <param name="ddd"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{ddd}/{phoneNumber}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FindPersonResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> FindPersonByContactNumber(int ddd, long phoneNumber, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new FindPersonByContactNumberQuery(ddd, phoneNumber), cancellationToken);

            return Ok(result);
        }


        /// <summary>
        /// Pesquisar uma lista de pessoas pelo o nome
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("list/{name}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FindPersonResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> FindPersonByName(string name, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new FindPersonByNameQuery(name), cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Inserir o registro de uma pessoa
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PostAsync([FromBody] PersonRequest request, CancellationToken cancellationToken)
        {
            var result = _mediator.Send(new InsertPersonCommand(request), cancellationToken);
            return Created(string.Empty, result);
        }

        /// <summary>
        /// Atualizar o registro de uma pessoa
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PutAsync([FromBody] PersonRequest request, CancellationToken cancellationToken)
        {
            var result = _mediator.Send(new UpdatePersonCommand(request), cancellationToken);
            return Ok(result);
        }
    }
}
