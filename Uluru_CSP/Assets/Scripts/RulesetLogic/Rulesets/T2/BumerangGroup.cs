using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumerangGroup : IRulesetLogic
{
    public PositionTokenTuple Origin { get; set; }
    private TokenEdge m_Short2Edge;
    private TokenEdge m_Long3Edge;
    private LogicOr m_Or;

    public BumerangGroup(PositionTokenTuple origin = null)
    {
        Origin = origin;
        m_Short2Edge = new TokenEdge(TokenEdge.enComparer.EQUALS, Edge.enEdgeID.Short_2, null);
        m_Long3Edge = new TokenEdge(TokenEdge.enComparer.EQUALS, Edge.enEdgeID.Long_3, null);
        m_Or = new LogicOr(m_Short2Edge, m_Long3Edge);
    }

    public bool Evaluate()
    {
        return m_Or != null ? m_Or.Evaluate() : false;
    }
}
