using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SameAs : IRulesetLogic
{
    private TokenABS m_Abs;

    public void Initialize(PositionTokenTuple origin, PositionTokenTuple dependecy)
    {
        
        /*if (origin != null && dependecy != null)
        {
            int dIndex = dependecy.Position.Index;
            int oIndex = origin.Position.Index;

            m_Abs = new TokenABS(TokenABS.enComparer.GREATER, 1, dIndex, oIndex);
        }
        else
        {
            m_Abs = null;
        }*/
    }

    public bool Evaluate()
    {
        return false;
        //return m_Abs != null ? m_Abs.Evaluate() : false;
    }
}
