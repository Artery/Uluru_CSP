using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicNot : IRulesetLogic
{
    public IRulesetLogic Object { get; set; }

    public LogicNot(IRulesetLogic obj = null)
    {
        Object = obj;
    }

    public bool Evaluate()
    {
        return Object != null ? !Object.Evaluate() : false;
    }
}

