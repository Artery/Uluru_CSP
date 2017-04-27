using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Edge
{
    public enum enEdgeID { Short_1 = 0, Short_2 = 34, Long_2 = 12, Long_3 = 57 };
    public enum enSide { LONG, SHORT };

    [SerializeField]
    private enSide m_side;
    [SerializeField]
    private int m_PositionCount;
    [SerializeField]
    private enEdgeID m_edgeID;

    public Edge(enEdgeID edgeID)
    {
        switch(edgeID)
        {
            case enEdgeID.Long_2:
                m_side = enSide.LONG;
                m_PositionCount = 2;
                break;
            case enEdgeID.Long_3:
                m_side = enSide.LONG;
                m_PositionCount = 3;
                break;
            case enEdgeID.Short_2:
                m_side = enSide.SHORT;
                m_PositionCount = 2;
                break;
            case enEdgeID.Short_1:
                m_side = enSide.SHORT;
                m_PositionCount = 1;
                break;
        }
    }

    public enSide Side
    {
        get
        {
            return m_side;
        }

        set
        {
            m_side = value;
        }
    }

    public int PositionCount
    {
        get
        {
            return m_PositionCount;
        }

        set
        {
            m_PositionCount = value;
        }
    }

    public enEdgeID EdgeID
    {
        get
        {
            return m_edgeID;
        }

        set
        {
            m_edgeID = value;
        }
    }
}
