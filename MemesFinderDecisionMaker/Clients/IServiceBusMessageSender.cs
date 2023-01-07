using System.Threading.Tasks;

namespace MemesFinderDecisionMaker.Clients
{
    public interface IServiceBusMessageSender
    {
        Task SendMessageAsync(string messageString);
    }
}