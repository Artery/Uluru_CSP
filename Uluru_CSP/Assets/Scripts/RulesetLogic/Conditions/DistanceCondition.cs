using UnityEngine;

public class DistanceCondition : IEvaluable
{
    public enLogicComparator Comparator { get; set; }

    public int DistanceValue { get; set; }
    public int FromIndex { get; set; }
    public int ToIndex { get; set; }

    public DistanceCondition(enLogicComparator comparator, int distanceValue, int fromIndex, int toIndex)
    {
        Comparator = comparator;
        DistanceValue = distanceValue;
        FromIndex = fromIndex;
        ToIndex = toIndex;
    }

    public bool Evaluate()
    {
        var absDistance = Mathf.Abs(FromIndex - ToIndex);
        var result = false;

        switch (Comparator)
        {
            case enLogicComparator.EQUALS:
                result = absDistance == DistanceValue;
                break;
            case enLogicComparator.UNEQUALS:
                result = absDistance != DistanceValue;
                break;
            case enLogicComparator.GREATER:
                result = absDistance > DistanceValue;
                break;
            case enLogicComparator.SMALLER:
                result = absDistance < DistanceValue;
                break;
            case enLogicComparator.GREATER_EQUALS:
                result = absDistance >= DistanceValue;
                break;
            case enLogicComparator.SMALLER_EQUALS:
                result = absDistance <= DistanceValue;
                break;
        }

        return result;
    }
}