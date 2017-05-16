public class InverseRuleset : IRuleset
{
    private IRuleset m_Ruleset;

    public InverseRuleset(IRuleset ruleset)
    {
        m_Ruleset = ruleset;
    }

    public void Initialize(PositionTokenTuple origin, PositionTokenTuple dependecy)
    {
    }

    public bool Evaluate()
    {
        return !m_Ruleset.Evaluate();
    }
}
