using Telegram.Bot.Types;

namespace MemesFinderDecisionMaker.Interfaces.DecisionMaker
{
    public interface IDecisionMaker
    {
        public ValueTask<Decision> GetDecisionAsync(Update update);
    }
}
