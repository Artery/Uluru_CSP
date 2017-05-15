using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenSide : IRulesetLogic
{
    public enum enComparer { EQUALS, UNEQUALS }

    public enComparer Comparer { get; set; }
    public Edge.enSide? OriginSide { get; set; }
    public Edge.enSide? DependencySide { get; set; }

    public TokenSide(enComparer comparer, Edge.enSide? dependencySide = null, Edge.enSide? originSide = null)
    {
        Comparer = comparer;
        OriginSide = originSide;
        DependencySide = dependencySide;
    }

    public bool Evaluate()
    {
        if(OriginSide.HasValue && DependencySide.HasValue)
        {
            if (Comparer == enComparer.EQUALS)
            {
                return OriginSide.Value == DependencySide.Value;
            }
            else if (Comparer == enComparer.UNEQUALS)
            {
                return OriginSide.Value != DependencySide.Value;
            }
        }
        return false;
    }
}
