using UnityEngine;

public class SideCondition : IEvaluable
{
    public enLogicComparator Comparator { get; set; }

    public Edge.enSide LhsSide { get; set; }
    public Edge.enSide RhsSide { get; set; }

    public SideCondition(enLogicComparator comparator, Edge.enSide lhsSide, Edge.enSide rhsSide)
    {
        Comparator = comparator;
        LhsSide = lhsSide;
        RhsSide = rhsSide;
    }

    public bool Evaluate()
    {
        var result = false;

        switch (Comparator)
        {
            case enLogicComparator.EQUALS:
                result = LhsSide == RhsSide;
                break;
            case enLogicComparator.UNEQUALS:
                result = LhsSide != RhsSide;
                break;
        }

        return result;
    }
}