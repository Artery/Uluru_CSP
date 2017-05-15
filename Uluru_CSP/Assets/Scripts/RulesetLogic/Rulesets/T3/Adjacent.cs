using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adjacent : IRulesetLogic
{
    private TokenABS m_Abs;
    private TokenEdge m_Edge;
    private LogicAnd m_And;

    public void Initialize(PositionTokenTuple origin, PositionTokenTuple dependecy)
    {
        if (origin != null && dependecy != null)
        {
            int dIndex = dependecy.Position.Index;
            int oIndex = origin.Position.Index;

            Edge.enEdgeID dEdgeID = dependecy.Position.Edge.EdgeID;
            Edge.enEdgeID oEdgeID = origin.Position.Edge.EdgeID;

            m_Abs = new TokenABS(TokenABS.enComparer.EQUALS, 1, dIndex, oIndex);
            m_Edge = new TokenEdge(TokenEdge.enComparer.EQUALS, dEdgeID, oEdgeID);

            m_And = new LogicAnd(m_Abs, m_Edge);
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
