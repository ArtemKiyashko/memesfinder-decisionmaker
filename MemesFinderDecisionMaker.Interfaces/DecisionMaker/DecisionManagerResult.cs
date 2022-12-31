namespace MemesFinderDecisionMaker.Interfaces.DecisionMaker
{
    public record DecisionManagerResult(bool Decision, IEnumerable<string>? Messages);
}