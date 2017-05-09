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

        m_RuleCardImage = m_RuleCard != null ? m_RuleCard.CardImage : null;
    }
}
