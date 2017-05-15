﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corner : IRulesetLogic
{
    public Position OriginPosition { get; set; }
    public Position DependencyPosition { get; set; }
    private TokenABS m_Abs;
    private TokenEdge m_Edge;
    private LogicAnd m_And;

    public Corner(Position dependencyPosition = null, Position originPosition = null)
    {
        OriginPosition = originPosition;
        DependencyPosition = dependencyPosition;

        int? dIndex = DependencyPosition != null ? (int?)DependencyPosition.Index : null;
        int? oIndex = OriginPosition != null ? (int?)OriginPosition.Index : null;

        Edge.enEdgeID? dEdgeID = DependencyPosition != null ? (Edge.enEdgeID?)DependencyPosition.Edge.EdgeID : null;
        Edge.enEdgeID? oEdgeID = OriginPosition != null ? (Edge.enEdgeID?)OriginPosition.Edge.EdgeID : null;

        m_Abs = new TokenABS(TokenABS.enComparer.EQUALS, 1, dIndex, oIndex);
        m_Edge = new TokenEdge(TokenEdge.enComparer.UNEQUALS, dEdgeID, oEdgeID);

        m_And = new LogicAnd(m_Abs, m_Edge);
    }

    public bool Evaluate()
    {
        return m_And != null ? m_And.Evaluate() : false;
    }
}
