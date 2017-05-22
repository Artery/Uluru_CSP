//Base Interface for all Rulesets
public interface IRuleset : IEvaluable
{
    void Initialize(PositionTokenTuple slotTuple, PositionTokenTuple rulesetTuple);
}
