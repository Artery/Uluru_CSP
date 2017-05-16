using UnityEngine;
using UnityEngine.UI;

public class RuleCard : MonoBehaviour
{
    [SerializeField]
    private Difficulty m_difficulty;
    [SerializeField]
    private Color m_Color;
    [SerializeField]
    private Ruleset m_ruleset;
    [SerializeField]
    private enRulesetType m_RulesetType;
    [SerializeField]
    private Image m_CardImage;

    void Start()
    {
        m_ruleset = new Ruleset(RulesetAdapter.GetRulesetLogic(RulesetType));
        m_ruleset.Color = Color;
    }

    public Difficulty Difficulty
    {
        get { return m_difficulty; }
        set { m_difficulty = value; }
    }

    public Color Color
    {
        get { return m_Color; }
        set { m_Color = value; }
    }

    public Ruleset Ruleset
    {
        get { return m_ruleset; }
        set { m_ruleset = value; }
    }

    public enRulesetType RulesetType
    {
        get { return m_RulesetType; }
        set { m_RulesetType = value; }
    }

    public Image CardImage
    {
        get { return m_CardImage; }
        set { m_CardImage = value; }
    }
}
