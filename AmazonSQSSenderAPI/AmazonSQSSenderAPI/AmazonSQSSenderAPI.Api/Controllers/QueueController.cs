using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonSQSSenderAPI.Api.Models;
using AmazonSQSSenderAPI.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AmazonSQSSenderAPI.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QueueController : ControllerBase
    {
        private readonly ISqsService _sqsService;
        public QueueController(ISqsService sqsService)
        {
            _sqsService = sqsService;
        }

        [HttpPost]
        [Route("sendmessage")]
        public async Task<IActionResult> SendMessage (TicketRequest request)
        {
            var response = await _sqsService.SendMessageToSqsQueue(request);

            if (request == null)
                return BadRequest();

            return Ok();
        }
    }
}
