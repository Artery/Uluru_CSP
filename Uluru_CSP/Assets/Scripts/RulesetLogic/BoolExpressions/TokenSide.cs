using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenSide : IBasicLogic
{
    public enum enComparer { EQUALS, UNEQUALS }

    public enComparer Comparer { get; set; }
    public Edge.enSide OriginSide { get; set; }
    public Edge.enSide DependencySide { get; set; }

    public TokenSide(enComparer comparer, Edge.enSide dependencySide, Edge.enSide originSide)
    {
        Comparer = comparer;
        OriginSide = originSide;
        DependencySide = dependencySide;
    }

    public bool Evaluate()
    {
        if (Comparer == enComparer.EQUALS)
        {
            return OriginSide == DependencySide;
        }
        else if (Comparer == enComparer.UNEQUALS)
        {
            return OriginSide != DependencySide;
        }
        return false;
    }
}
