using Azure.Messaging.ServiceBus;
using MemesFinderDecisionMaker.Extentions;
using MemesFinderDecisionMaker.Interfaces.AzureClient;
using MemesFinderDecisionMaker.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MemesFinderDecisionMaker.Clients
{
    //serialise the object and send it to the server 
    public class ServiceBusModelSender : IServiceBusModelSender
    {
        private readonly ILogger<ServiceBusModelSender> _logger;
        private readonly IServiceBusClient _serviceBusClient;

        public ServiceBusModelSender(ILogger<ServiceBusModelSender> log, IServiceBusClient serviceBusClient)
        {
            _logger = log;
            _serviceBusClient = serviceBusClient;
        }

        public async Task SendMessageAsync(TgMessageModel tgMessageModel)
        {
            try
            {
                await using ServiceBusSender sender = _serviceBusClient.CreateSender();
                ServiceBusMessage serviceBusMessage = new(tgMessageModel.ToJson());
                await sender.SendMessageAsync(serviceBusMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while sending message to Service Bus");
            }
        }

    }


}