using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortSide : IRulesetLogic
{
    private TokenEdge m_Short2Edge;
    private TokenEdge m_Short1Edge;
    private LogicOr m_Or;

    public void Initialize(PositionTokenTuple origin, PositionTokenTuple dependecy)
    {
        if (origin != null)
        {
            m_Short1Edge = new TokenEdge(TokenEdge.enComparer.EQUALS, Edge.enEdgeID.Short_1, origin.Position.Edge.EdgeID);
            m_Short2Edge = new TokenEdge(TokenEdge.enComparer.EQUALS, Edge.enEdgeID.Short_2, origin.Position.Edge.EdgeID);

            m_Or = new LogicOr(m_Short1Edge, m_Short2Edge);
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
