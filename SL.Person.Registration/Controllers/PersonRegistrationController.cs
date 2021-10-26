using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Domain.RegistrationAggregate;
using MediatR;
using System.Threading;
using SL.Person.Registration.Application.Query;
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

        [HttpGet("{documentNumber}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(200, Type = typeof(InformationRegistration))]
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
        [ProducesResponseType(201, Type = typeof(InsertPersonCommand))]
        public IActionResult PostAsync([FromBody] InsertPersonCommand command, CancellationToken cancellationToken)
        {
            var result = _mediator.Send(command, cancellationToken);

            return Created("", result);
        }

        /// <summary>
        /// Atualizar o registro de uma pessoa
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesDefaultResponseType]
        [ProducesResponseType(200, Type = typeof(UpdatePersonCommand))]
        public IActionResult PutAsync([FromBody] UpdatePersonCommand command, CancellationToken cancellationToken)
        {
            var result = _mediator.Send(command, cancellationToken);

            return Ok(result);
        }
    }
}
