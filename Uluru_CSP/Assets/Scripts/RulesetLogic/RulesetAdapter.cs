using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesetAdapter
{
    public static IRuleset GetRulesetLogic(enRulesetType rulesetType)
    {
        IRuleset ruleset = null;

        switch(rulesetType)
        {
            case enRulesetType.NO_PREFERENCE:
                ruleset = new NoPreference();
                break;
            case enRulesetType.BUMERANG_GROUP:
                ruleset = new BumerangGroup();
                break;
            case enRulesetType.LONLEY_GROUP:
                ruleset = new LonleyGroup();
                break;
            case enRulesetType.LONG_SIDE:
                ruleset = new LongSide();
                break;
            case enRulesetType.SHORT_SIDE:
                ruleset = new ShortSide();
                break;
            case enRulesetType.ADJACENT:
                ruleset = new Adjacent();
                break;
            case enRulesetType.AROUND_THE_CORNER:
                ruleset = new AroundTheCorner();
                break;
            case enRulesetType.OPPOSITE_SIDE:
                ruleset = new OppositeSide();
                break;
            case enRulesetType.MINIMUM_DISTANCE_2:
                ruleset = new MinimumDistance2();
                break;
            case enRulesetType.NOT_ADJACENT_NOT_OPPOSITE_SIDE:
                ruleset = new NotAdjacentNotOppositeSide();
                break;
            case enRulesetType.SAME_AS:
                ruleset = new NoPreference();
                break;
            case enRulesetType.CONTRARY_OF:
                ruleset = new NoPreference();
                break;
        }

        return ruleset;
    }
}
