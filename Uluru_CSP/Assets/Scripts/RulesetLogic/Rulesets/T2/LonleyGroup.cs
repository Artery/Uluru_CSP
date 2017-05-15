using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LonleyGroup : IRulesetLogic
{
    public PositionTokenTuple Origin { get; set; }
    private TokenEdge m_Short1Edge;
    private TokenEdge m_Long2Edge;
    private LogicOr m_Or;

    /*public LonleyGroup(PositionTokenTuple origin = null)
    {
        Origin = origin;
        m_Short1Edge = new TokenEdge(TokenEdge.enComparer.EQUALS, Edge.enEdgeID.Short_1, null);
        m_Long2Edge = new TokenEdge(TokenEdge.enComparer.EQUALS, Edge.enEdgeID.Long_2, null);
        m_Or = new LogicOr(m_Short1Edge, m_Long2Edge);
    }*/

    public void Initialize(PositionTokenTuple origin, PositionTokenTuple dependecy)
    {
        m_Short1Edge = new TokenEdge(TokenEdge.enComparer.EQUALS, Edge.enEdgeID.Short_1, origin.Position.Edge.EdgeID);
        m_Long2Edge = new TokenEdge(TokenEdge.enComparer.EQUALS, Edge.enEdgeID.Long_2, origin.Position.Edge.EdgeID);
        m_Or = new LogicOr(m_Short1Edge, m_Long2Edge);
    }

    public bool Evaluate()
    {
        return m_Or != null ? m_Or.Evaluate() : false;
    }
}
