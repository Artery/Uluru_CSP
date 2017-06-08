using UnityEngine;

/// <summary>
/// Class summary goes here...
/// </summary>
public class DistanceCondition : IEvaluable
{
    #region Fields
    #endregion

    #region Properties
    public enLogicComparator Comparator { get; set; }
    public int DistanceValue { get; set; }
    public int FromIndex { get; set; }
    public int ToIndex { get; set; }
    #endregion

    #region Constructors
    public DistanceCondition(enLogicComparator comparator, int distanceValue, int fromIndex, int toIndex)
    {
        Comparator = comparator;
        DistanceValue = distanceValue;
        FromIndex = fromIndex;
        ToIndex = toIndex;
    }
    #endregion

    #region Methods
    #region InterfaceMethods
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
    #endregion
    #region ClassMethods
    #endregion
    #endregion
}