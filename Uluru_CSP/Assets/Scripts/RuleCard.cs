using UnityEngine;

public class RuleCard : MonoBehaviour
{
    [SerializeField]
    private Difficulty m_difficulty;
    [SerializeField]
    private Ruleset m_ruleset;

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
}
