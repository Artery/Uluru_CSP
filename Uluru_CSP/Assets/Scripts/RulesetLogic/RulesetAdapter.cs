using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesetAdapter
{
    public static IRulesetLogic GetRulesetLogic(enRulesetType ruleSetType)
    {
        IRulesetLogic ruleSetLogic = null;

        if(ruleSetType == enRulesetType.IDONTKNOW)
        {
            ruleSetLogic = new IDontKnow();
        }
        else if (ruleSetType == enRulesetType.BUMERANGGROUP)
        {
            ruleSetLogic = new BumerangGroup();
        }
        else if (ruleSetType == enRulesetType.LONLEYGROUP)
        {
            ruleSetLogic = new LonleyGroup();
        }
        else if (ruleSetType == enRulesetType.LONGSIDE)
        {
            ruleSetLogic = new LongSide();
        }
        else if (ruleSetType == enRulesetType.SHORTSIDE)
        {
            ruleSetLogic = new ShortSide();
        }
        else if (ruleSetType == enRulesetType.ADJACENT)
        {
            ruleSetLogic = new Adjacent();
        }
        else if (ruleSetType == enRulesetType.CORNER)
        {
            ruleSetLogic = new Corner();
        }
        else if (ruleSetType == enRulesetType.OPPOSITE)
        {
            ruleSetLogic = new Opposite();
        }
        else if (ruleSetType == enRulesetType.MIN2AWAY)
        {
            ruleSetLogic = new Min2Away();
        }
        else if (ruleSetType == enRulesetType.NOTADJACENTNOTOPPOSITE)
        {
            ruleSetLogic = new NotAdjacentNotOpposite();
        }

        return ruleSetLogic;
    }
}
