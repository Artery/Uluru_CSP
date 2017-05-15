using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicNot : IBasicLogic
{
    public IBasicLogic Object { get; set; }

    public LogicNot(IBasicLogic obj)
    {
        Object = obj;
    }

    public bool Evaluate()
    {
        return Object != null ? !Object.Evaluate() : false;
    }
}

