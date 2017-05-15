using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotAdjacentNotOpposite : IRulesetLogic
{
    private LogicNot m_lhsNot;
    private LogicNot m_rhsNot;
    private LogicAnd m_And;

    public void Initialize(PositionTokenTuple origin, PositionTokenTuple dependecy)
    {
        if (origin != null && dependecy != null)
        {
            var adjacent = new Adjacent();
            adjacent.Initialize(origin, dependecy);

            var opposite = new Opposite();
            opposite.Initialize(origin, dependecy);

            m_lhsNot = new LogicNot(adjacent);
            m_rhsNot = new LogicNot(opposite);

            m_And = new LogicAnd(m_lhsNot, m_rhsNot);
        }
        else
        {
            m_And = null;
        }
    }

    public bool Evaluate()
    {
        return m_And != null ? m_And.Evaluate() : false;
    }
}
