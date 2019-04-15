using System;
using System.Threading.Tasks;

namespace NetCore.SignalR_HostedService.Interfaces
{
    public interface IProcessor
    {
        Task Process(string process);
    }
}
