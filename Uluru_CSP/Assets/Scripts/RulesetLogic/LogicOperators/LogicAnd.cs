using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicAnd : IBasicLogic
{
    public IBasicLogic Lhs { get; set; }
    public IBasicLogic Rhs { get; set; }

    public LogicAnd(IBasicLogic lhs, IBasicLogic rhs)
    {
        Lhs = lhs;
        Rhs = rhs;
    }

    public bool Evaluate()
    {
        Debug.Log("LogicAnd");
        Debug.Log(Lhs.GetType());
        Debug.Log(Rhs);
        return Lhs != null && Rhs != null ? Lhs.Evaluate() && Rhs.Evaluate() : false;
    }
}
