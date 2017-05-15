using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenABS : IBasicLogic
{
    public enum enComparer { EQUALS, UNEQUALS, GREATER, SMALLER, GREATER_EQUALS, SMALLER_EQUALS }

    public int ABSValue { get; set; }
    public enComparer Comparer { get; set; }
    public int OriginIndex { get; set; }
    public int DependencyIndex { get; set; }

    public TokenABS(enComparer comparer, int absValue, int dependencyIndex, int originIndex)
    {
        Comparer = comparer;
        ABSValue = absValue;
        OriginIndex = originIndex;
        DependencyIndex = dependencyIndex;
    }

    public bool Evaluate()
    {
        if(Comparer == enComparer.EQUALS)
        {
            return Mathf.Abs(OriginIndex - DependencyIndex) == ABSValue;
        }
        else if (Comparer == enComparer.GREATER_EQUALS)
        {
            return Mathf.Abs(OriginIndex - DependencyIndex) >= ABSValue;
        }
        else if (Comparer == enComparer.GREATER)
        {
            return Mathf.Abs(OriginIndex - DependencyIndex) > ABSValue;
        }

        return false;
    }
}
