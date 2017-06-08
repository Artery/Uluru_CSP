using UnityEngine;

/// <summary>
/// Class summary goes here...
/// </summary>
public class EdgeCondition : IEvaluable
{
    #region Fields
    #endregion

    #region Properties
    public enLogicComparator Comparator { get; set; }
    public Edge.enEdgeID LhsEdge { get; set; }
    public Edge.enEdgeID RhsEdge { get; set; }
    #endregion

    #region Constructors
    public EdgeCondition(enLogicComparator comparator, Edge.enEdgeID lhsEdge, Edge.enEdgeID rhsEdge)
    {
        Comparator = comparator;
        LhsEdge = lhsEdge;
        RhsEdge = rhsEdge;
    }
    #endregion

    #region Methods
    #region InterfaceMethods
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
    #endregion
    #region ClassMethods
    #endregion
    #endregion
}