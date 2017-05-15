using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Min2Away : IRulesetLogic
{
    public Position OriginPosition { get; set; }
    public Position DependencyPosition { get; set; }
    private TokenABS m_Abs;

    public Min2Away(Position dependencyPosition = null, Position originPosition = null)
    {
        OriginPosition = originPosition;
        DependencyPosition = dependencyPosition;

        int? dIndex = DependencyPosition != null ? (int?)DependencyPosition.Index : null;
        int? oIndex = OriginPosition != null ? (int?)OriginPosition.Index : null;

        m_Abs = new TokenABS(TokenABS.enComparer.GREATER, 1, dIndex, oIndex);
    }

    public bool Evaluate()
    {
        return m_Abs != null ? m_Abs.Evaluate() : false;
    }
}
