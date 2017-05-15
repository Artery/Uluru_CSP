using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDontKnow : IRulesetLogic
{
    public IDontKnow()
    {
    }

    public void Initialize(PositionTokenTuple origin, PositionTokenTuple dependecy)
    {
    }

    public bool Evaluate()
    {
        return true;
    }
}
