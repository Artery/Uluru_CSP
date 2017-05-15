using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opposite : IRulesetLogic
{
    private TokenEdge m_Edge;
    private TokenSide m_Side;
    private LogicAnd m_And;

    public void Initialize(PositionTokenTuple origin, PositionTokenTuple dependecy)
    {
        if (origin != null && dependecy != null)
        {
            Edge.enSide dSide = dependecy.Position.Edge.Side;
            Edge.enSide oSide = origin.Position.Edge.Side;

            Edge.enEdgeID dEdgeID = dependecy.Position.Edge.EdgeID;
            Edge.enEdgeID oEdgeID = origin.Position.Edge.EdgeID;

            m_Side = new TokenSide(TokenSide.enComparer.EQUALS, dSide, oSide);
            m_Edge = new TokenEdge(TokenEdge.enComparer.UNEQUALS, dEdgeID, oEdgeID);

            m_And = new LogicAnd(m_Side, m_Edge);
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
