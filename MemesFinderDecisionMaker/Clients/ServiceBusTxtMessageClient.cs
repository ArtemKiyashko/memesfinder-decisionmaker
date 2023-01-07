using Azure.Messaging.ServiceBus;
using MemesFinderDecisionMaker.Interfaces.AzureClient;
using MemesFinderDecisionMaker.Options;
using Microsoft.Extensions.Options;

namespace MemesFinderDecisionMaker.Clients
{
    internal class ServiceBusTxtMessageClient : IServiceBusClient
    {
        private readonly ServiceBusClient _serviceBusClient;
        private readonly ServiceBusOptions _serviceBusOptions;

        public ServiceBusTxtMessageClient(ServiceBusClient serviceBusClient, IOptions<ServiceBusOptions> serviceBusOptions)
        {
            _serviceBusClient = serviceBusClient;
            _serviceBusOptions = serviceBusOptions.Value;
        }

        public ServiceBusSender CreateSender() => _serviceBusClient.CreateSender(_serviceBusOptions.TextMessagesTopic);
    }
}
