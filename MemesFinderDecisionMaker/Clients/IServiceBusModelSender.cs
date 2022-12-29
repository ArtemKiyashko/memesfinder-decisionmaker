using MemesFinderDecisionMaker.Models;
using System.Threading.Tasks;

namespace MemesFinderDecisionMaker.Clients
{
    public interface IServiceBusModelSender
    {
        Task SendMessageAsync(TgMessageModel tgMessageModel);
    }
}