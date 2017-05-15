using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongSide : IRulesetLogic
{
    public PositionTokenTuple Origin { get; set; }
    private TokenEdge m_Long2Edge;
    private TokenEdge m_Long3Edge;
    private LogicOr m_Or;

    /*public LongSide(PositionTokenTuple origin = null)
    {
        Origin = origin;
        m_Long2Edge = new TokenEdge(TokenEdge.enComparer.EQUALS, Edge.enEdgeID.Long_2, null);
        m_Long3Edge = new TokenEdge(TokenEdge.enComparer.EQUALS, Edge.enEdgeID.Long_3, null);
        m_Or = new LogicOr(m_Long2Edge, m_Long3Edge);
    }*/

    public void Initialize(PositionTokenTuple origin, PositionTokenTuple dependecy)
    {
        m_Long2Edge = new TokenEdge(TokenEdge.enComparer.EQUALS, Edge.enEdgeID.Long_2, origin.Position.Edge.EdgeID);
        m_Long3Edge = new TokenEdge(TokenEdge.enComparer.EQUALS, Edge.enEdgeID.Long_3, origin.Position.Edge.EdgeID);
        m_Or = new LogicOr(m_Long2Edge, m_Long3Edge);
    }

    public bool Evaluate()
    {
        return m_Or != null ? m_Or.Evaluate() : false;
    }
}
