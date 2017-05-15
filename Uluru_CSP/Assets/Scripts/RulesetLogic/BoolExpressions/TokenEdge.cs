using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenEdge : IRulesetLogic
{
    public enum enComparer { EQUALS, UNEQUALS }

    public enComparer Comparer { get; set; }
    public Edge.enEdgeID? OriginEdge { get; set; }
    public Edge.enEdgeID? DependencyEdge { get; set; }

    public TokenEdge(enComparer comparer, Edge.enEdgeID? dependencyEdge = null, Edge.enEdgeID? originEdge = null)
    {
        Comparer = comparer;
        OriginEdge = originEdge;
        DependencyEdge = dependencyEdge;
    }

    public bool Evaluate()
    {
        if (OriginEdge.HasValue && DependencyEdge.HasValue)
        {
            if (Comparer == enComparer.EQUALS)
            {
                return OriginEdge.Value == DependencyEdge.Value;
            }
            else if (Comparer == enComparer.UNEQUALS)
            {
                return OriginEdge.Value != DependencyEdge.Value;
            }
        }
        return false;
    }
}
