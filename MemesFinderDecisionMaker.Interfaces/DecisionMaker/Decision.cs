namespace MemesFinderDecisionMaker.Interfaces.DecisionMaker
{
    public record Decision(
        bool DecisionResult,
        string Message = null);
}