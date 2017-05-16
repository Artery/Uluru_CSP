using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LonleyGroup : IRuleset
{
    private EdgeCondition m_Short1Edge;
    private EdgeCondition m_Long2Edge;
    private LogicalOr m_Or;

    public void Initialize(PositionTokenTuple slotTuple, PositionTokenTuple rulesetTuple)
    {
        if (slotTuple != null)
        {
            m_Short1Edge = new EdgeCondition(enLogicComparator.EQUALS, Edge.enEdgeID.Short_1, slotTuple.Position.Edge.EdgeID);
            m_Long2Edge = new EdgeCondition(enLogicComparator.EQUALS, Edge.enEdgeID.Long_2, slotTuple.Position.Edge.EdgeID);
            m_Or = new LogicalOr(m_Short1Edge, m_Long2Edge);
        }
        else
        {
            m_Or = null;
        }
    }

    public bool Evaluate()
    {
        return m_Or != null ? m_Or.Evaluate() : false;
    }
}
