using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotAdjacentNotOpposite : IRulesetLogic
{
    public Adjacent Adjacent { get; set; }
    public Opposite Opposite { get; set; }
    private LogicNot m_lhsNot;
    private LogicNot m_rhsNot;
    private LogicAnd m_And;

    /*public NotAdjacentNotOpposite(Adjacent adjacent = null, Opposite opposite = null)
    {
        Adjacent = adjacent;
        Opposite = opposite;

        m_lhsNot = new LogicNot(Adjacent);
        m_rhsNot = new LogicNot(Opposite);

        m_And = new LogicAnd(m_lhsNot, m_rhsNot);
    }*/

    public void Initialize(PositionTokenTuple origin, PositionTokenTuple dependecy)
    {
        var adjacent = new Adjacent();
        adjacent.Initialize(origin, dependecy);

        var opposite = new Opposite();
        opposite.Initialize(origin, dependecy);

        m_lhsNot = new LogicNot(adjacent);
        m_rhsNot = new LogicNot(opposite);

        m_And = new LogicAnd(m_lhsNot, m_rhsNot);
    }

    public bool Evaluate()
    {
        return m_And != null ? m_And.Evaluate() : false;
    }
}
