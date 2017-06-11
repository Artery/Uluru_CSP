using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class represents one Token, each Player will have 8
/// Each Token has to be placed on one unique Position
/// </summary>
public class Token : UIButtonBase
{
    #region Fields
    #region SerializedFields
    [SerializeField]
    private enColor m_Color;
    [SerializeField]
    private UnityEngine.Color m_UIColor;
    #endregion
    #endregion

    #region Properties
    public UnityEngine.Color UIColor
    {
        get { return m_UIColor; }
        set { m_UIColor = value; }
    }

    public enColor Color
    {
        get { return m_Color; }
        set { m_Color = value; }
    }
    #endregion

    #region Constructors
    public Token(enColor color)
    {
        this.Color = color;
    }
    #endregion

    #region Methods
    #region MonoMethods
    void Awake() { }

    void Start() { }

    void Update() { }
    #endregion

    #region ClassMethods
    #endregion
    #endregion
}
