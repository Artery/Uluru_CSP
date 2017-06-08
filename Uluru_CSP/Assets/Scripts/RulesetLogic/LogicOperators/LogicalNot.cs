/// <summary>
/// Class summary goes here...
/// </summary>
public class LogicalNot : IEvaluable
{
    #region Fields
    #endregion

    #region Properties
    public IEvaluable Object { get; set; }
    #endregion

    #region Constructors
    public LogicalNot(IEvaluable obj)
    {
        Object = obj;
    }
    #endregion

    #region Methods
    #region InterfaceMethods
    public bool Evaluate()
    {
        return Object != null && !Object.Evaluate();
    }
    #endregion
    #region ClassMethods
    #endregion
    #endregion
}
