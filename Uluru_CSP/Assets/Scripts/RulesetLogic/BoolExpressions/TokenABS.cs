using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenABS : IBasicLogic
{
    public enum enComparer { EQUALS, UNEQUALS, GREATER, SMALLER, GREATER_EQUALS, SMALLER_EQUALS }

    public int ABSValue { get; set; }
    public enComparer Comparer { get; set; }
    public int? OriginIndex { get; set; }
    public int? DependencyIndex { get; set; }

    public TokenABS(enComparer comparer, int absValue, int? dependencyIndex, int? originIndex)
    {
        Comparer = comparer;
        ABSValue = absValue;
        OriginIndex = originIndex;
        DependencyIndex = dependencyIndex;
    }

    public bool Evaluate()
    {
        Debug.Log("YO");
        if (OriginIndex.HasValue && DependencyIndex.HasValue)
        {
            if (Comparer == enComparer.EQUALS)
            {
                Debug.Log(Mathf.Abs(OriginIndex.Value - DependencyIndex.Value));
                return Mathf.Abs(OriginIndex.Value - DependencyIndex.Value) == ABSValue;
            }
            else if (Comparer == enComparer.GREATER_EQUALS)
            {
                Debug.Log("GreaterEquals");
                return Mathf.Abs(OriginIndex.Value - DependencyIndex.Value) >= ABSValue;
            }
            else
            {
                Debug.Log("inner ELSE");
                
            }
        }
        else
        {
            Debug.Log("outer ELSE");

        }
        Debug.Log("false");    

        return false;
    }
}
