using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQSendLinkedInLink.Controllers
{
    [Route("api/test")]
    [ApiController]

    public class RabbitMQController: ControllerBase
    {
        private readonly IRabbitMQService _rabbitMQService;

        public RabbitMQController(IRabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }

        [HttpGet("rabbitMQ")]
        public IActionResult TestRabbitMQ()
        {
            _rabbitMQService.CreateMessage(new RabbitMQMessage { LinkedInLink = "https://www.linkedin.com/in/catalina-prioteasa-320116186/" });
            return Ok();
        }
    }
}
