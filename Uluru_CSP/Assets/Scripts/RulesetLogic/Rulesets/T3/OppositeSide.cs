﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class summary goes here...
/// </summary>
public class OppositeSide: IRuleset
{
    #region Fields
    private SideCondition m_SideCondition;
    private EdgeCondition m_EdgeCondition;
    private LogicalAnd m_And;
    #endregion

    #region Properties
    #endregion

    #region Constructors
    #endregion

    #region Methods
    #region InterfaceMethods
    public void Initialize(PositionTokenTuple slotTuple, PositionTokenTuple rulesetTuple)
    {
        if (slotTuple != null && rulesetTuple != null)
        {
            Edge.enSide slotTokenPositionSide = slotTuple.Position.Edge.Side;
            Edge.enSide rulesetTokenPositionSide = rulesetTuple.Position.Edge.Side;

            Edge.enEdgeID slotTokenPositionEdge = slotTuple.Position.Edge.EdgeID;
            Edge.enEdgeID rulesetTokenPositionEdge = rulesetTuple.Position.Edge.EdgeID;

            m_SideCondition = new SideCondition(enLogicComparator.EQUALS, slotTokenPositionSide, rulesetTokenPositionSide);
            m_EdgeCondition = new EdgeCondition(enLogicComparator.UNEQUALS, slotTokenPositionEdge, rulesetTokenPositionEdge);

            m_And = new LogicalAnd(m_SideCondition, m_EdgeCondition);
        }
        else
        {
            m_And = null;
        }
    }

    public bool Evaluate()
    {
        return m_And != null && m_And.Evaluate();
    }
    #endregion
    #region ClassMethods
    #endregion
    #endregion
}
