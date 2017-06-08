using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class summary goes here...
/// </summary>
public class Scoreboard : MonoBehaviour
{
    #region Fields
    #region SerializedFields
    [SerializeField]
    private Text m_NameField;
    [SerializeField]
    private Text m_DrawbackField;
    [SerializeField]
    private Text m_RoundField;
    [SerializeField]
    private Text m_RemainingTimeField;
    #endregion
    #endregion

    #region Properties
    public Text NameField
    {
        get { return m_NameField; }
    }

    public Text DrawbackField
    {
        get { return m_DrawbackField; }
    }

    public Text RoundField
    {
        get { return m_RoundField; }
    }

    public Text RemainingTimeField
    {
        get { return m_RemainingTimeField; }
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
    public void UpdateRemainingTime(double remainingTime)
    {
        var time = remainingTime.ToString();
        time = time.Substring(0, Math.Min(time.Length, 6));

        RemainingTimeField.text = time + "s";//Math.Round(remainingTime, 3) + "s";
    }
    #endregion
    #endregion
}
