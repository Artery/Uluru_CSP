using UnityEngine;

/// <summary>
/// Class summary goes here...
/// </summary>
public class SideCondition : IEvaluable
{
    #region Fields
    #endregion

    #region Properties
    public enLogicComparator Comparator { get; set; }
    public Edge.enSide LhsSide { get; set; }
    public Edge.enSide RhsSide { get; set; }
    #endregion

    #region Constructors
    public SideCondition(enLogicComparator comparator, Edge.enSide lhsSide, Edge.enSide rhsSide)
    {
        Comparator = comparator;
        LhsSide = lhsSide;
        RhsSide = rhsSide;
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
                result = LhsSide == RhsSide;
                break;
            case enLogicComparator.UNEQUALS:
                result = LhsSide != RhsSide;
                break;
        }

        return result;
    }
    #endregion
    #region ClassMethods
    #endregion
    #endregion
}