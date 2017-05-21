using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotAdjacentNotOppositeSide : IRuleset
{
    private LogicalNot m_NotAdjacent;
    private LogicalNot m_NotOppositeSide;
    private LogicalAnd m_And;

    public void Initialize(PositionTokenTuple slotTuple, PositionTokenTuple rulesetTuple)
    {
        if (slotTuple != null && rulesetTuple != null)
        {
            var adjacent = new Adjacent();
            adjacent.Initialize(slotTuple, rulesetTuple);

            var oppositeSide = new OppositeSide();
            oppositeSide.Initialize(slotTuple, rulesetTuple);

            m_NotAdjacent = new LogicalNot(adjacent);
            m_NotOppositeSide = new LogicalNot(oppositeSide);

            m_And = new LogicalAnd(m_NotAdjacent, m_NotOppositeSide);
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
}
