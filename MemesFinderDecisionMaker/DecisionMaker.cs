using MemesFinderDecisionMaker.Clients;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Telegram.Bot.Types;

namespace MemesFinderDecisionMaker
{
    public class DecisionMaker
    {
        private readonly ILogger<DecisionMaker> _logger;
        private readonly IServiceBusModelSender _serviceBusModelSender;

        public DecisionMaker(
            ILogger<DecisionMaker> log,
            IServiceBusModelSender serviceBusModelSender)
        {
            _logger = log;
            _serviceBusModelSender = serviceBusModelSender;
        }

        [FunctionName("Function1")]
        public void Run([ServiceBusTrigger("allmessages", "decisionmaker", Connection = "ServiceBusOptions")] Update tgMessage)
        {
            _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {tgMessage}");
        }
    }
}
