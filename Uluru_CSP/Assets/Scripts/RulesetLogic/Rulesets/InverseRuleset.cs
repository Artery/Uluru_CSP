public class InverseRuleset : IRuleset
{
    private IRuleset m_Ruleset;

    public InverseRuleset(IRuleset ruleset)
    {
        m_Ruleset = ruleset;
    }

    public void Initialize(PositionTokenTuple slotTuple, PositionTokenTuple rulesetTuple)
    {
        m_Ruleset.Initialize(slotTuple, rulesetTuple);
    }

    public bool Evaluate()
    {
        return !m_Ruleset.Evaluate();
    }
}
