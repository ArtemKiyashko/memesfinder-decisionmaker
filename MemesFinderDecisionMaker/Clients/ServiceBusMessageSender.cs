using Azure.Messaging.ServiceBus;
using MemesFinderDecisionMaker.Interfaces.AzureClient;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MemesFinderDecisionMaker.Clients
{
    //send object to the server 
    public class ServiceBusMessageSender : IServiceBusMessageSender
    {
        private readonly ILogger<DecisionMaker> _logger;
        private readonly IServiceBusClient _serviceBusClient;

        public ServiceBusMessageSender(ILogger<DecisionMaker> log, IServiceBusClient serviceBusClient)
        {
            _logger = log;
            _serviceBusClient = serviceBusClient;
        }

        public async Task SendMessageAsync(string messageString)
        {
            try
            {
                await using ServiceBusSender sender = _serviceBusClient.CreateSender();
                ServiceBusMessage serviceBusMessage = new(messageString);
                await sender.SendMessageAsync(serviceBusMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while sending message to Service Bus");
                return;
            }
        }

    }


}