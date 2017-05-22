//Base class for all binary LogicOperators
public abstract class LogicOperatorBase : IEvaluable
{
    public IEvaluable Lhs { get; set; }
    public IEvaluable Rhs { get; set; }

    public LogicOperatorBase(IEvaluable lhs, IEvaluable rhs)
    {
        Lhs = lhs;
        Rhs = rhs;
    }

    public abstract bool Evaluate();
}
