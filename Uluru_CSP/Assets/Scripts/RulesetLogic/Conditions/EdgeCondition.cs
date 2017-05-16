using UnityEngine;

public class EdgeCondition : IEvaluable
{
    public enLogicComparator Comparator { get; set; }

    public Edge.enEdgeID LhsEdge { get; set; }
    public Edge.enEdgeID RhsEdge { get; set; }

    public EdgeCondition(enLogicComparator comparator, Edge.enEdgeID lhsEdge, Edge.enEdgeID rhsEdge)
    {
        Comparator = comparator;
        LhsEdge = lhsEdge;
        RhsEdge = rhsEdge;
    }

    public bool Evaluate()
    {
        var result = false;

        switch (Comparator)
        {
            case enLogicComparator.EQUALS:
                result = LhsEdge == RhsEdge;
                break;
            case enLogicComparator.UNEQUALS:
                result = LhsEdge != RhsEdge;
                break;
        }

        return result;
    }
}