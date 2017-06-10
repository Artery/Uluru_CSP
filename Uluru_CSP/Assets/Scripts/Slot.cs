using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class summary goes here...
/// </summary>
public class Slot : MonoBehaviour
{
    #region Fields
    #region SerializedFields
    [SerializeField]
    private Color m_Color;
    [SerializeField]
    private RuleCard m_RuleCard;
    [SerializeField]
    private Image m_RuleCardImage;
    #endregion
    private UnityEngine.Color[] colors = new UnityEngine.Color[]{
                                                                    UnityEngine.Color.white, UnityEngine.Color.magenta, UnityEngine.Color.yellow, new UnityEngine.Color(180, 100, 10),
                                                                    UnityEngine.Color.red, UnityEngine.Color.green, UnityEngine.Color.blue, UnityEngine.Color.black };
    #endregion

    #region Properties
    public Color Color
    {
        get { return m_Color; }
        set { m_Color = value; }
    }

    public RuleCard RuleCard
    {
        get { return m_RuleCard; }
        set { m_RuleCard = value; }
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
    public void SetRuleCard(RuleCard ruleCard)
    {
        m_RuleCard = ruleCard;
        GetComponentInChildren<Text>().text = "";

        //m_RuleCardImage = m_RuleCard != null ? m_RuleCard.CardImage : null;
        if (m_RuleCard != null && m_RuleCard.CardImage != null)
        {
            var cardImage = m_RuleCard.CardImage;

            m_RuleCardImage.sprite = cardImage.sprite;
            m_RuleCardImage.color = cardImage.color;
            m_RuleCardImage.material = cardImage.material;

            //Temp hack for UI
            GetComponentInChildren<Text>().text = m_RuleCard.RulesetType.ToString();
            GetComponentInChildren<Text>().color = RuleCard.Color == Color.NONE ? UnityEngine.Color.cyan : colors[(int)m_RuleCard.Color];
        }
    }
    #endregion
    #endregion
}
