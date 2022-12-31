using Telegram.Bot.Types;

namespace MemesFinderDecisionMaker.Interfaces.DecisionMaker
{
    public interface IDecisionMakerManager
    {
        public ValueTask<DecisionManagerResult> GetFinalDecisionAsync(Update tgUpdate);
    }
}
