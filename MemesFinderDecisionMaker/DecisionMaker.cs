using MemesFinderDecisionMaker.Clients;
using MemesFinderDecisionMaker.Extentions;
using MemesFinderDecisionMaker.Interfaces.DecisionMaker;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace MemesFinderDecisionMaker
{
    public class DecisionMaker
    {
        private readonly ILogger<DecisionMaker> _logger;
        private readonly IServiceBusMessageSender _serviceBusMessageSender;
        private readonly IDecisionMakerManager _deciscionMakerManager;

        public DecisionMaker(
            ILogger<DecisionMaker> log,
            IServiceBusMessageSender serviceBusMessageSender,
            IDecisionMakerManager deciscionMakerManager)
        {
            _logger = log;
            _serviceBusMessageSender = serviceBusMessageSender;
            _deciscionMakerManager = deciscionMakerManager;
        }

        [FunctionName("DecisionMaker")]
        public async Task Run([ServiceBusTrigger("allmessages", "decisionmaker", Connection = "ServiceBusOptions")] Update tgMessage)
        {
            string messageString = tgMessage.ToJson();

            var decision = await _deciscionMakerManager.GetFinalDecisionAsync(tgMessage);

            if (!decision.Decision)
            {
                HandleNegativeDecision(_logger, decision);
                return;
            }

            await _serviceBusMessageSender.SendMessageAsync(messageString);
        }

        private static void HandleNegativeDecision(ILogger log, DecisionManagerResult decision)
        {
            var aggregatedMessages = decision.Messages
                .Aggregate((f, s) => $"{f}{Environment.NewLine}{s}");
            log.LogInformation($"Negative decision taken: {aggregatedMessages}");
        }
    }
}
