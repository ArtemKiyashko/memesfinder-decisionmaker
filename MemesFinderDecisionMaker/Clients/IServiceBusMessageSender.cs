using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MemesFinderDecisionMaker.Clients
{
    public interface IServiceBusMessageSender
    {
        Task<IActionResult> SendMessageAsync(string messageString);
    }
}