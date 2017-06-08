/// <summary>
/// Class summary goes here...
/// </summary>
public class InverseRuleset : IRuleset
{
    #region Fields
    private IRuleset m_Ruleset;
    #endregion

    #region Properties
    #endregion

    #region Constructors
    public InverseRuleset(IRuleset ruleset)
    {
        m_Ruleset = ruleset;
    }
    #endregion

    #region Methods
    #region InterfaceMethods
    public void Initialize(PositionTokenTuple slotTuple, PositionTokenTuple rulesetTuple)
    {
        m_Ruleset.Initialize(slotTuple, rulesetTuple);
    }

    public bool Evaluate()
    {
        return !m_Ruleset.Evaluate();
    }
    #endregion
    #region ClassMethods
    #endregion
    #endregion
}
