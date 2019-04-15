using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NetCore.SignalR_HostedService.DataStorage;
using NetCore.SignalR_HostedService.Hubs;
using NetCore.SignalR_HostedService.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCore.SignalR_HostedService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    { 
        public IBackgroundTaskQueue _queue { get; }
        public IProcessor _processor { get; }

        public ChartController( IBackgroundTaskQueue queue, IProcessor processor)
        { 
            _queue = queue;
            _processor = processor;
        }
        [HttpGet ]
        public IActionResult Get( )
        {
            _queue.QueueBackgroundWorkItem(async token =>
            {
                await _processor.Process("");
            });
            return Ok(new { Message = "Request Completed" });
        } 
    }
}
