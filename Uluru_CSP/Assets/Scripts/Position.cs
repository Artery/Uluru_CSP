using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// //This class represents one Position on e.g. the Gameboard
/// </summary>
public class Position : UIButtonBase
{
    #region Fields
    #region SerializedFields
    [SerializeField]
    private int m_Index;
    [SerializeField]
    private Edge m_Edge;
    [SerializeField]
    private Image m_TokenImage;
    #endregion
    #endregion

    #region Properties
    public int Index
    {
        get { return m_Index; }
        protected set { m_Index = value; }
    }

    public Edge Edge
    {
        get { return m_Edge; }
        set { m_Edge = value; }
    }

    public Image TokenImage
    {
        get { return m_TokenImage; }
        set { m_TokenImage = value; }
    }
    #endregion

    #region Constructors
    public Position(int index, Edge edge)
    {
        Index = index;
        Edge = edge;
    }
    #endregion

    #region Methods
    #region MonoMethods
    void Awake() { }

    void Start() { }

    void Update() { }
    #endregion

    #region ClassMethods
    public void UpdateTokenImageColor(UnityEngine.Color? tokenColor)
    {
        if (tokenColor != null)
        {
            TokenImage.enabled = true;
            TokenImage.color = tokenColor.Value;
        }
        else
        {
            TokenImage.enabled = false;
        }
    }
    #endregion
    #endregion
}
