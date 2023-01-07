using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace MemesFinderDecisionMaker.Clients
{
    public interface IServiceBusMessageSender
    {
        Task SendMessageAsync(Update message);
    }
}