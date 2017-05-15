using UnityEngine;
using UnityEngine.UI;

public class RuleCard : MonoBehaviour
{
    [SerializeField]
    private Difficulty m_difficulty;
    [SerializeField]
    private Ruleset m_ruleset;
    [SerializeField]
    private Image m_CardImage;
    [SerializeField]
    private enRulesetType m_RulesetType;

    void Start()
    {
        m_ruleset = new Ruleset(RulesetAdapter.GetRulesetLogic(RulesetType));
    }

    public Difficulty Difficulty
    {
        get { return m_difficulty; }
        set { m_difficulty = value; }
    }
    public Ruleset Ruleset
    {
        get { return m_ruleset; }
        set { m_ruleset = value; }
    }

    public Image CardImage
    {
        get { return m_CardImage; }
        set { m_CardImage = value; }
    }

    public enRulesetType RulesetType
    {
        get { return m_RulesetType; }
        set { m_RulesetType = value; }
    }
}
