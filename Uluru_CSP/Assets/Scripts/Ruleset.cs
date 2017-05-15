using System;
using UnityEngine;

public class Ruleset
{
    public Color Color { get; set; }

    public IRulesetLogic RulesetLogic { get; set; }

    public Ruleset(IRulesetLogic rulesetLogic)
    {
        RulesetLogic = rulesetLogic;
    }

    public bool VerfiyRuleset(PositionTokenTuple slotTuple, PositionTokenTuple rulesetTuple)
    {
        bool result = false;

        if(slotTuple != null)
        {
            if(Color == slotTuple.Token.Color)
            {
                result = true;
            }
            else
            {
                RulesetLogic.Initialize(slotTuple, rulesetTuple);
                result = RulesetLogic.Evaluate();
            }
        }

        Debug.Log(result);

        return result;
        //throw new NotImplementedException();
    }
}
