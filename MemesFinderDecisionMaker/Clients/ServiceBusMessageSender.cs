using Azure.Messaging.ServiceBus;
using MemesFinderDecisionMaker.Extentions;
using MemesFinderDecisionMaker.Interfaces.AzureClient;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Telegram.Bot.Types;

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

        public async Task SendMessageAsync(Update message)
        {
            await using ServiceBusSender sender = _serviceBusClient.CreateSender();
            ServiceBusMessage serviceBusMessage = new(message.ToJson());
            await sender.SendMessageAsync(serviceBusMessage);
        }

    }


}