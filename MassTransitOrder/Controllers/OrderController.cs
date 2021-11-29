using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MassTransitOrder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndPoint;
        public OrderController(IPublishEndpoint publishEndPoint)
        {
            this._publishEndPoint = publishEndPoint; //help us publishing a message into the rabbitmq
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult> Post()
        {
            //await _publishEndPoint.Publish<Order>(order);
            await _publishEndPoint.Publish<Order>(new Order { LinkedInLink = "https://www.linkedin.com/in/catalina-prioteasa-320116186/"});
            return Ok();
        }
    }
}
