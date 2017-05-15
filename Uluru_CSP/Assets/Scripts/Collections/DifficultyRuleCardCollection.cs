using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DifficultyRuleCardCollection
{
    [SerializeField]
    private Difficulty m_Difficulty;
    [SerializeField]
    private List<RuleCard> m_RuleCards;

    public Difficulty Difficulty
    {
        get
        {
            return m_Difficulty;
        }

        set
        {
            m_Difficulty = value;
        }
    }

    public List<RuleCard> RuleCards
    {
        get
        {
            return m_RuleCards;
        }

        protected set
        {
            m_RuleCards = value;
        }
    }
}
