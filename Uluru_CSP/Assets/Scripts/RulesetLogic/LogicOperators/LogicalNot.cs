public class LogicalNot : IEvaluable
{
    public IEvaluable Object { get; set; }

    public LogicalNot(IEvaluable obj)
    {
        Object = obj;
    }

    public bool Evaluate()
    {
        return Object != null && !Object.Evaluate();
    }
}
