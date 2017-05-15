using System;
using UnityEngine;

public class Ruleset
{
    public Color Color { get; set; }

    public IRulesetLogic RulesetLogic { get; set; }

    public bool VerfiyRuleset(PositionTokenTuple slotTuple, PositionTokenTuple rulesetTuple)
    {
        RulesetLogic.Initialize(slotTuple, rulesetTuple);
        return RulesetLogic.Evaluate();
        //throw new NotImplementedException();
    }
}
