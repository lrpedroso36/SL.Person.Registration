using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Application.Results;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static SL.Person.Registration.Application.Command.InsertWorkSchedulesCommand;

namespace SL.Person.Registration.Api.Controllers
{
    [ApiController]
    [Route("api/v1/work-schedule")]
    public class WorkScheduleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WorkScheduleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Inserir escala de trabalho
        /// </summary>
        /// <param name="id">'Id' da pessoa</param>
        /// <param name="works">Lista de escalas</param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Escalas inserida com sucesso</response>
        /// <response code="400">Informe o 'Id' da pessoa</response>
        /// <response code="404">Pessoa não econtrado</response>
        /// <returns></returns>
        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Result))]
        public async Task PutAsync(string id, [FromBody] List<WorkScheduleCommand> works, CancellationToken cancellationToken)
            => await _mediator.Send(new InsertWorkSchedulesCommand(id, works), cancellationToken);
    }
}
