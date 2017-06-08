/// <summary>
/// Base Interface for all Rulesets
/// </summary>
public interface IRuleset : IEvaluable
{
    void Initialize(PositionTokenTuple slotTuple, PositionTokenTuple rulesetTuple);
}
