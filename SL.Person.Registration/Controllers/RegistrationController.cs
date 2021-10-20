using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SL.Person.Registration.Domain.RegistrationAggregate;

namespace SL.Person.Registration.Controllers
{
    [ApiController]
    [Route("api/v1/register")]
    public class RegistrationController : ControllerBase
    {
       
        private readonly ILogger<RegistrationController> _logger;

        public RegistrationController(ILogger<RegistrationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesDefaultResponseType]
        [ProducesResponseType(200, Type = typeof(InformationRegistration))]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
