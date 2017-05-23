using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField]
    private Color m_Color;
    [SerializeField]
    private RuleCard m_RuleCard;
    [SerializeField]
    private Image m_RuleCardImage;

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
            if (RuleCard.Color == Color.NONE)
            {
                GetComponentInChildren<Text>().color = UnityEngine.Color.cyan;
            }
            else
            {
                
                GetComponentInChildren<Text>().color = colors[(int)m_RuleCard.Color];
            }
        }
    }

    private UnityEngine.Color[] colors = new UnityEngine.Color[]{
        UnityEngine.Color.white, UnityEngine.Color.magenta, UnityEngine.Color.yellow, new UnityEngine.Color(0.9f, 0.6f, 0.05f), 
        UnityEngine.Color.red, UnityEngine.Color.green, UnityEngine.Color.blue, UnityEngine.Color.black };
}
