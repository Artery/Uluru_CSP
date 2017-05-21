using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortSide : IRuleset
{
    private EdgeCondition m_Short2Edge;
    private EdgeCondition m_Short1Edge;
    private LogicalOr m_Or;

    public void Initialize(PositionTokenTuple slotTuple, PositionTokenTuple rulesetTuple)
    {
        if (slotTuple != null)
        {
            m_Short2Edge = new EdgeCondition(enLogicComparator.EQUALS, Edge.enEdgeID.Short_2, slotTuple.Position.Edge.EdgeID);
            m_Short1Edge = new EdgeCondition(enLogicComparator.EQUALS, Edge.enEdgeID.Short_1, slotTuple.Position.Edge.EdgeID);
            m_Or = new LogicalOr(m_Short2Edge, m_Short1Edge);
        }
        else
        {
            m_Or = null;
        }
    }

    public bool Evaluate()
    {
        return m_Or != null && m_Or.Evaluate();
    }
}
