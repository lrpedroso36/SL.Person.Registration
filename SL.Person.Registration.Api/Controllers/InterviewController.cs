using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SL.Person.Registration.Application.Command;
using SL.Person.Registration.Domain.Requests;
using System.Threading;

namespace SL.Person.Registration.Api.Controllers
{
    [ApiController]
    [Route("api/v1/interview")]
    public class InterviewController : ControllerBase
    {
        private IMediator _mediator;

        public InterviewController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Inserir a entrevista
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PostAsync([FromBody] InterviewRequest request, CancellationToken cancellationToken)
        {
            var result = _mediator.Send(new InsertInterviewCommand(request), cancellationToken);
            return Created(string.Empty, result);
        }
    }
}
