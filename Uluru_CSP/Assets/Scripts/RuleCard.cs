using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class summary goes here...
/// </summary>
public class RuleCard : MonoBehaviour
{
    #region Fields
    #region SerializedFields
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
    #endregion
    #endregion

    #region Properties
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
    #endregion

    #region Constructors
    #endregion

    #region Methods
    #region MonoMethods
    void Awake() { }

    void Start()
    {
        m_Ruleset = new Ruleset(RulesetAdapter.GetRulesetLogic(RulesetType)) {Color = Color, RulesetType = RulesetType};
    }

    void Update() { }
    #endregion

    #region ClassMethods
    #endregion
    #endregion
}
