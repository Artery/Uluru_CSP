using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class summary goes here...
/// </summary>
public class Edge : MonoBehaviour
{
    #region Enums
    public enum enEdgeID { SHORT_1 = 0, SHORT_2 = 34, LONG_2 = 12, LONG_3 = 57 };
    public enum enSide { LONG, SHORT };
    #endregion

    #region Fields
    #region SerializedFields
    [SerializeField]
    private enSide m_Side;
    [SerializeField]
    private int m_PositionCount;
    [SerializeField]
    private enEdgeID m_EdgeID;
    #endregion
    #endregion

    #region Properties
    public enSide Side
    {
        get { return m_Side; }
        set { m_Side = value; }
    }

    public int PositionCount
    {
        get { return m_PositionCount; }
        set { m_PositionCount = value; }
    }

    public enEdgeID EdgeID
    {
        get { return m_EdgeID; }
        set { m_EdgeID = value; }
    }
    #endregion

    #region Constructors
    public Edge(enEdgeID edgeID)
    {
        switch (edgeID)
        {
            case enEdgeID.LONG_2:
                m_Side = enSide.LONG;
                m_PositionCount = 2;
                break;
            case enEdgeID.LONG_3:
                m_Side = enSide.LONG;
                m_PositionCount = 3;
                break;
            case enEdgeID.SHORT_2:
                m_Side = enSide.SHORT;
                m_PositionCount = 2;
                break;
            case enEdgeID.SHORT_1:
                m_Side = enSide.SHORT;
                m_PositionCount = 1;
                break;
        }
    }
    #endregion

    #region Methods
    #region MonoMethods
    void Awake() { }

    void Start() { }

    void Update() { }
    #endregion

    #region ClassMethods
    #endregion
    #endregion
}
