using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField]
    private Color m_Color;
    [SerializeField]
    private RuleCard m_RuleCard;

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
}
