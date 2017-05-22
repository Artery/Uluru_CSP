using UnityEngine;
using UnityEngine.UI;

public class RuleCard : MonoBehaviour
{
    [SerializeField]
    private Difficulty m_Difficulty;
    [SerializeField]
    private Color m_Color;
    [SerializeField]
    private Ruleset m_Ruleset;
    [SerializeField]
    private enRulesetType m_RulesetType;
    [SerializeField]
    private Image m_CardImage;

    void Start()
    {
        m_Ruleset = new Ruleset(RulesetAdapter.GetRulesetLogic(RulesetType));
        m_Ruleset.Color = Color;
        m_Ruleset.RulesetType = RulesetType;
    }

    public Difficulty Difficulty
    {
        get { return m_Difficulty; }
        set { m_Difficulty = value; }
    }

    public Color Color
    {
        get { return m_Color; }
        set { m_Color = value; }
    }

    public Ruleset Ruleset
    {
        get { return m_Ruleset; }
        set { m_Ruleset = value; }
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
