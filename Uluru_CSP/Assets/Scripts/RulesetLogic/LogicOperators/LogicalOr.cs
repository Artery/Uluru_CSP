/// <summary>
/// Class summary goes here...
/// </summary>
public class LogicalOr : LogicOperatorBase
{
    #region Fields
    #endregion

    #region Properties
    #endregion

    #region Constructors
    public LogicalOr(IEvaluable lhs, IEvaluable rhs) : base(lhs, rhs) { }
    #endregion

    #region Methods
    #region InterfaceMethods
    public override bool Evaluate()
    {
        return Lhs != null && Rhs != null && (Lhs.Evaluate() || Rhs.Evaluate());
    }
    #endregion
    #region ClassMethods
    #endregion
    #endregion
}
