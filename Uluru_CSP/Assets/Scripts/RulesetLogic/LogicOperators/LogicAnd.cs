using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicAnd : IRulesetLogic
{
    public IRulesetLogic Lhs { get; set; }
    public IRulesetLogic Rhs { get; set; }

    public LogicAnd(IRulesetLogic lhs = null, IRulesetLogic rhs = null)
    {
        Lhs = lhs;
        Rhs = rhs;
    }

    public bool Evaluate()
    {
        return Lhs != null && Rhs != null ? Lhs.Evaluate() && Rhs.Evaluate() : false;
    }
}
