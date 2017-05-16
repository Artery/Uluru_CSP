using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adjacent: IRuleset
{
    private DistanceCondition m_DistanceCondition;
    private EdgeCondition m_EdgeCondition;
    private LogicalAnd m_And;

    public void Initialize(PositionTokenTuple slotTuple, PositionTokenTuple rulesetTuple)
    {
        if (slotTuple != null && rulesetTuple != null)
        {
            int slotTokenPositionIndex = slotTuple.Position.Index;
            int rulesetTokenPositionIndex = rulesetTuple.Position.Index;

            Edge.enEdgeID slotTokenPositionEdge = slotTuple.Position.Edge.EdgeID;
            Edge.enEdgeID rulesetTokenPositionEdge = rulesetTuple.Position.Edge.EdgeID;

            m_DistanceCondition = new DistanceCondition(enLogicComparator.EQUALS, 1, slotTokenPositionIndex, rulesetTokenPositionIndex);
            m_EdgeCondition = new EdgeCondition(enLogicComparator.EQUALS, slotTokenPositionEdge, rulesetTokenPositionEdge);

            m_And = new LogicalAnd(m_DistanceCondition, m_EdgeCondition);
        }
        else
        {
            m_And = null;
        }
    }

    public bool Evaluate()
    {
        return m_And != null ? m_And.Evaluate() : false;
    }
}
