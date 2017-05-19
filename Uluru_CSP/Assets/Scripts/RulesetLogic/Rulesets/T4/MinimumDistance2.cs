using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimumDistance2 : IRuleset
{
    private DistanceCondition m_DistanceCondition;

    public void Initialize(PositionTokenTuple slotTuple, PositionTokenTuple rulesetTuple)
    {
        if (slotTuple != null && rulesetTuple != null)
        {
            int slotTokenPositionIndex = slotTuple.Position.Index;
            int rulesetTokenPositionIndex = rulesetTuple.Position.Index;

            m_DistanceCondition = new DistanceCondition(enLogicComparator.GREATER_EQUALS, 2, slotTokenPositionIndex, rulesetTokenPositionIndex);
        }
        else
        {
            m_DistanceCondition = null;
        }
    }

    public bool Evaluate()
    {
        return m_DistanceCondition != null && m_DistanceCondition.Evaluate();
    }
}
