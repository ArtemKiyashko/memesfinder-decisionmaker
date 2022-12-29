using Azure.Messaging.ServiceBus;

namespace MemesFinderDecisionMaker.Interfaces.AzureClient
{
    public interface IServiceBusClient
    {
        public ServiceBusSender CreateSender();
    }
}