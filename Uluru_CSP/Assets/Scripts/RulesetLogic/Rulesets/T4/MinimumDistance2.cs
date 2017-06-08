using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class summary goes here...
/// </summary>
public class MinimumDistance2 : IRuleset
{
    #region Fields
    private DistanceCondition m_DistanceCondition;
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
            int slotTokenPositionIndex = slotTuple.Position.Index;
            int rulesetTokenPositionIndex = rulesetTuple.Position.Index;

            m_DistanceCondition = new DistanceCondition(enLogicComparator.GREATER, 2, slotTokenPositionIndex, rulesetTokenPositionIndex);
        }
        else
        {
            m_DistanceCondition = null;
        }
    }

    public bool Evaluate()
    {
        return m_DistanceCondition != null && m_DistanceCondition.Evaluate();
    }
    #endregion
    #region ClassMethods
    #endregion
    #endregion
}
