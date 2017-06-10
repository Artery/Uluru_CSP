using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class summary goes here...
/// </summary>
public class UIButtonBase : MonoBehaviour
{
    #region Fields
    #region SerializedFields
    [SerializeField]
    protected bool m_IsUnlocked;
    [SerializeField]
    protected Button m_Button;
    #endregion
    #endregion

    #region Properties
    public Button Button
    {
        get { return m_Button; }
        protected set { m_Button = value; }
    }

    public bool IsUnlocked
    {
        get { return m_IsUnlocked; }
        set
        {
            if (m_IsUnlocked != value)
            {
                m_IsUnlocked = value;
                m_Button.interactable = m_IsUnlocked;
            }
        }
    }
    #endregion

    #region Constructors
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
