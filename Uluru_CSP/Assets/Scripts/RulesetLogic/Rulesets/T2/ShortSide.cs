using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortSide : IRulesetLogic
{
    public PositionTokenTuple Origin { get; set; }
    private TokenEdge m_Short2Edge;
    private TokenEdge m_Short1Edge;
    private LogicOr m_Or;

    public ShortSide(PositionTokenTuple origin = null)
    {
        Origin = origin;
        m_Short2Edge = new TokenEdge(TokenEdge.enComparer.EQUALS, Edge.enEdgeID.Short_2, null);
        m_Short1Edge = new TokenEdge(TokenEdge.enComparer.EQUALS, Edge.enEdgeID.Short_1, null);
        m_Or = new LogicOr(m_Short2Edge, m_Short1Edge);
    }

    public bool Evaluate()
    {
        return m_Or != null ? m_Or.Evaluate() : false;
    }
}
