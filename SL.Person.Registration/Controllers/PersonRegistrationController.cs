using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SL.Person.Registration.Application.Command;
using MediatR;
using System.Threading;
using SL.Person.Registration.Application.Query;
using System.Threading.Tasks;
using SL.Person.Registration.Domain.Requests;
using SL.Person.Registration.Domain.Results;
using Microsoft.AspNetCore.Http;

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
        /// Inserir o registro de uma pessoa
        /// </summary>
        /// <param name="command"></param>
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
        /// <param name="command"></param>
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
