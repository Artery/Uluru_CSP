﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenEdge : IBasicLogic
{
    public enum enComparer { EQUALS, UNEQUALS }

    public enComparer Comparer { get; set; }
    public Edge.enEdgeID OriginEdge { get; set; }
    public Edge.enEdgeID DependencyEdge { get; set; }

    public TokenEdge(enComparer comparer, Edge.enEdgeID dependencyEdge, Edge.enEdgeID originEdge)
    {
        Comparer = comparer;
        OriginEdge = originEdge;
        DependencyEdge = dependencyEdge;
    }

    public bool Evaluate()
    {
        if (Comparer == enComparer.EQUALS)
        {
            return OriginEdge == DependencyEdge;
        }
        else if (Comparer == enComparer.UNEQUALS)
        {
            return OriginEdge != DependencyEdge;
        }

        return false;
    }
}
