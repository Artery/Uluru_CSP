/// <summary>
/// Base class for all binary LogicOperators
/// </summary>
public abstract class LogicOperatorBase : IEvaluable
{
    #region Fields
    #endregion

    #region Properties
    public IEvaluable Lhs { get; set; }
    public IEvaluable Rhs { get; set; }
    #endregion

    #region Constructors
    public LogicOperatorBase(IEvaluable lhs, IEvaluable rhs)
    {
        Lhs = lhs;
        Rhs = rhs;
    }
    #endregion

    #region Methods
    #region InterfaceMethods
    public abstract bool Evaluate();
    #endregion
    #region ClassMethods
    #endregion
    #endregion
}
