using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class summary goes here...
/// </summary>
public class LonleyGroup : IRuleset
{
    #region Fields
    private EdgeCondition m_Short1EdgeCondition;
    private EdgeCondition m_Long2EdgeCondition;
    private LogicalOr m_Or;
    #endregion

    #region Properties
    #endregion

    #region Constructors
    #endregion

    #region Methods
    #region InterfaceMethods
    public void Initialize(PositionTokenTuple slotTuple, PositionTokenTuple rulesetTuple)
    {
        if (slotTuple != null)
        {
            m_Short1EdgeCondition = new EdgeCondition(enLogicComparator.EQUALS, Edge.enEdgeID.Short_1, slotTuple.Position.Edge.EdgeID);
            m_Long2EdgeCondition = new EdgeCondition(enLogicComparator.EQUALS, Edge.enEdgeID.Long_2, slotTuple.Position.Edge.EdgeID);
            m_Or = new LogicalOr(m_Short1EdgeCondition, m_Long2EdgeCondition);
        }
        else
        {
            m_Or = null;
        }
    }

    public bool Evaluate()
    {
        return m_Or != null && m_Or.Evaluate();
    }
    #endregion
    #region ClassMethods
    #endregion
    #endregion
}
