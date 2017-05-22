﻿using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameboard : MonoBehaviour
{
    [SerializeField]
    protected List<PositionTokenTuple> m_PositionsTokens;
    [SerializeField]
    protected bool m_IsUnlocked = false;

    public List<PositionTokenTuple> PositionsTokens
    {
        get
        {
            return m_PositionsTokens;
        }
    }

    public PositionCollection Positions
    {
        get
        {
            return new PositionCollection(m_PositionsTokens.Select(tuple => tuple.Position));
        }
    }

    public TokenCollection Tokens
    {
        get
        {
            return new TokenCollection(m_PositionsTokens.Select(tuple => tuple.Token));
        }
    }

    public bool IsUnlocked
    {
        get { return m_IsUnlocked; }

        set
        {
            if (m_IsUnlocked != value)
            {
                m_IsUnlocked = value;
                Positions.ForEach(position => position.IsUnlocked = m_IsUnlocked);
            }
        }
    }

    public virtual void Reset() { }

    public List<Color> VerifyBoardState(List<Slot> gameplanState)
    {
        var wrongTokens = new List<Color>();

        foreach (var slot in gameplanState)
        {
            PositionTokenTuple rulesetTuple = null;
            var slotTuple = m_PositionsTokens.FirstOrDefault(tuple => tuple.Token != null && tuple.Token.Color.Equals(slot.Color));
            var ruleset = slot.RuleCard.Ruleset;

            HandleChainedRulesets(gameplanState, ref ruleset);

            if (ruleset != null && !ruleset.Color.Equals(Color.NONE))
            {  
                rulesetTuple = m_PositionsTokens.FirstOrDefault(tuple => tuple.Token != null && tuple.Token.Color.Equals(ruleset.Color));
            }

            if (ruleset == null || !ruleset.VerfiyRuleset(slotTuple, rulesetTuple))
            {
                wrongTokens.Add(slot.Color);
            }
        }

        Debug.Log(wrongTokens.Count);

        return wrongTokens;
    }

    //ToDo
    //Needs to be refactor, this should not be in Gameboard
    private static void HandleChainedRulesets(List<Slot> gameplanState, ref Ruleset ruleset)
    {
        var inverseRuleset = ruleset.RulesetType == enRulesetType.CONTRARY_OF;

        while (ruleset.RulesetType == enRulesetType.SAME_AS || ruleset.RulesetType == enRulesetType.CONTRARY_OF)
        {
            var rulesetColor = ruleset.Color;
            var linkedSlot = gameplanState.FirstOrDefault(slot => slot.Color == rulesetColor);

            if (linkedSlot != null)
            {
                ruleset = linkedSlot.RuleCard.Ruleset;

                inverseRuleset = inverseRuleset != (ruleset.RulesetType == enRulesetType.CONTRARY_OF);

                if (linkedSlot.Color == ruleset.Color || ruleset.RulesetType == enRulesetType.NO_PREFERENCE)
                {
                    break;
                }
            }
            else
            {
                inverseRuleset = false;
                ruleset = null;
                break;
            }
        }

        if (inverseRuleset)
        {
            ruleset.RulesetLogic = new InverseRuleset(ruleset.RulesetLogic);
        }
    }
}
