public class LogicalOr : LogicOperatorBase
{
    public LogicalOr(IEvaluable lhs, IEvaluable rhs) : base(lhs, rhs) { }

    public override bool Evaluate()
    {
        return Lhs != null && Rhs != null && (Lhs.Evaluate() || Rhs.Evaluate());
    }
}
