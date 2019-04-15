using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using NetCore.SignalR_HostedService.DataStorage;
using NetCore.SignalR_HostedService.Hubs;
using NetCore.SignalR_HostedService.Interfaces;

namespace NetCore.SignalR_HostedService
{
    public class Processor : IProcessor
    {
        private IHubContext<ChartHub> _hub; 

        public Processor(IHubContext<ChartHub> hub )
        {
            _hub = hub; 
        }
        public async Task Process(string process)
        {
            await Task.Delay(5000);
            var guid = Guid.NewGuid().ToString();
            //await _hub.Clients.Group(process).SendAsync("transferchartdata", DataManager.GetData()); 
            await _hub.Clients.All.SendAsync("transferchartdata", DataManager.GetData());
        }
    }
}
