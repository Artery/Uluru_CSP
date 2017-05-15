using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opposite : IRulesetLogic
{
    public Position OriginPosition { get; set; }
    public Position DependencyPosition { get; set; }
    private TokenEdge m_Edge;
    private TokenSide m_Side;
    private LogicAnd m_And;

    public Opposite(Position dependencyPosition = null, Position originPosition = null)
    {
        OriginPosition = originPosition;
        DependencyPosition = dependencyPosition;

        Edge.enEdgeID? dEdgeID = DependencyPosition != null ? (Edge.enEdgeID?) DependencyPosition.Edge.EdgeID : null;
        Edge.enEdgeID? oEdgeID = OriginPosition != null ? (Edge.enEdgeID?)OriginPosition.Edge.EdgeID : null;

        Edge.enSide? dSide = DependencyPosition != null ? (Edge.enSide?)DependencyPosition.Edge.Side : null;
        Edge.enSide? oSide = OriginPosition != null ? (Edge.enSide?)OriginPosition.Edge.Side : null;

        m_Side = new TokenSide(TokenSide.enComparer.UNEQUALS, dSide, oSide);
        m_Edge = new TokenEdge(TokenEdge.enComparer.UNEQUALS, dEdgeID, oEdgeID);
        m_And = new LogicAnd(m_Side, m_Edge);
    }

    public bool Evaluate()
    {
        return m_And != null ? m_And.Evaluate() : false;
    }
}
