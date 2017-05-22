public class LogicalAnd : LogicOperatorBase
{
    public LogicalAnd(IEvaluable lhs, IEvaluable rhs) : base(lhs, rhs)
    {
    }

    public override bool Evaluate()
    {
        return Lhs != null && Rhs != null && (Lhs.Evaluate() && Rhs.Evaluate());
    }
}
