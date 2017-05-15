using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicOr : IBasicLogic
{
    public IBasicLogic Lhs { get; set; }
    public IBasicLogic Rhs { get; set; }

    public LogicOr(IBasicLogic lhs, IBasicLogic rhs)
    {
        Lhs = lhs;
        Rhs = rhs;
    }

    public bool Evaluate()
    {
        return Lhs != null && Rhs != null ? Lhs.Evaluate() || Rhs.Evaluate() : false;
    }
}
