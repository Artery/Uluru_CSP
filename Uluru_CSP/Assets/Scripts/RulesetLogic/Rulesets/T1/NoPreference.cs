using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoPreference : IRuleset
{
    public NoPreference()
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
