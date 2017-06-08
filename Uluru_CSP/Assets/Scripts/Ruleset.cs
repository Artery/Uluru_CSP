using System;
using UnityEngine;

/// <summary>
/// Class summary goes here...
/// </summary>
public class Ruleset
{
    #region Fields
    #endregion

    #region Properties
    public Color Color { get; set; }
    public enRulesetType RulesetType { get; set; }
    public IRuleset RulesetLogic { get; set; }
    #endregion

    #region Constructors
    public Ruleset(IRuleset ruleset)
    {
        RulesetLogic = ruleset;
    }
    #endregion

    #region Methods
    #region ClassMethods
    public bool VerfiyRuleset(PositionTokenTuple slotTuple, PositionTokenTuple rulesetTuple)
    {
        bool result = false;

        //If the slotToken is not set, the ruleset could never be fullfilled
        if (slotTuple != null)
        {
            //Tokens can't fullfill a condition which includes it's color
            //E.g. if the RuleCard in the WhiteSlot is "Adjacent-White", 
            //then it's not possible, but in this case it's automatically fullfilled 
            if (Color == slotTuple.Token.Color)
            {
                result = true;
            }
            else
            {
                //Initialize and evaluate ruleset
                RulesetLogic.Initialize(slotTuple, rulesetTuple);
                result = RulesetLogic.Evaluate();
            }
        }

        return result;
    }
    #endregion
    #endregion
}
