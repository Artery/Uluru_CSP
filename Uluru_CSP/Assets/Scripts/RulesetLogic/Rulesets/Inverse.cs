using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverse : IRulesetLogic
{
    private IRulesetLogic m_RulesetLogic;

    public Inverse(IRulesetLogic rulesetLogic)
    {
        m_RulesetLogic = rulesetLogic;
    }

    public void Initialize(PositionTokenTuple origin, PositionTokenTuple dependecy)
    {
    }

    public bool Evaluate()
    {
        return !m_RulesetLogic.Evaluate();
    }
}
