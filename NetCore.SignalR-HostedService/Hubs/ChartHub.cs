using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace NetCore.SignalR_HostedService.Hubs
{
    public class ChartHub : Hub
    {
        [HubMethodName("Subscribe")]
        public async Task Subscribe(string process)
        { 
            await Groups.AddToGroupAsync(Context.ConnectionId, process);
        }
        [HubMethodName("UnSubscribe")]
        public async Task UnSubscribe(string process)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, process);
        }
    }
}
