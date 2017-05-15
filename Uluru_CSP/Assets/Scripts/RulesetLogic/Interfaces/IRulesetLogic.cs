using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRulesetLogic : IBasicLogic
{
    void Initialize(PositionTokenTuple origin, PositionTokenTuple dependecy);

    //bool Evaluate();
}
