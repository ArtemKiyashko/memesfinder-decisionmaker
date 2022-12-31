using Azure.Messaging.ServiceBus;
using MemesFinderDecisionMaker.Interfaces.AzureClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MemesFinderDecisionMaker.Clients
{
    //send object to the server 
    public class ServiceBusMessageSender : IServiceBusMessageSender
    {
        private readonly ILogger<ServiceBusMessageSender> _logger;
        private readonly IServiceBusClient _serviceBusClient;

        public ServiceBusMessageSender(ILogger<ServiceBusMessageSender> log, IServiceBusClient serviceBusClient)
        {
            _logger = log;
            _serviceBusClient = serviceBusClient;
        }

        public async Task<IActionResult> SendMessageAsync(string messageString)
        {
            try
            {
                await using ServiceBusSender sender = _serviceBusClient.CreateSender();
                ServiceBusMessage serviceBusMessage = new(messageString);
                await sender.SendMessageAsync(serviceBusMessage);

                return new OkResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while sending message to Service Bus");
                return new BadRequestObjectResult("Something went wrong, try again later");
            }
        }

    }


}