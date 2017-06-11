using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class summary goes here...
/// </summary>
public class Gameboard : MonoBehaviour
{
    #region Fields
    #region SerializedFields
    [SerializeField]
    protected List<PositionTokenTuple> m_PositionsTokens;
    [SerializeField]
    protected bool m_IsUnlocked;
    #endregion
    #endregion

    #region Properties
    public List<PositionTokenTuple> PositionsTokens => m_PositionsTokens;

    public PositionCollection Positions => new PositionCollection(m_PositionsTokens.Select(tuple => tuple.Position));

    public TokenCollection Tokens => new TokenCollection(m_PositionsTokens.Select(tuple => tuple.Token));

    public bool IsUnlocked
    {
        get { return m_IsUnlocked; }

        set
        {
            if (m_IsUnlocked != value)
            {
                m_IsUnlocked = value;
                Positions.ForEach(position => position.IsUnlocked = m_IsUnlocked);
            }
        }
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
    public virtual void Clear() { }

    public List<enColor> VerifyBoardState(List<Slot> gameplanState)
    {
        var wrongTokens = new List<enColor>();

        foreach (var slot in gameplanState)
        {
            PositionTokenTuple rulesetTuple = null;
            var slotTuple = m_PositionsTokens.FirstOrDefault(tuple => tuple.Token != null && tuple.Token.Color.Equals(slot.Color));
            var ruleset = slot.RuleCard.Ruleset;

            HandleChainedRulesets(gameplanState, ref ruleset);

            if (ruleset != null && !ruleset.Color.Equals(enColor.NONE))
            {
                rulesetTuple = m_PositionsTokens.FirstOrDefault(tuple => tuple.Token != null && tuple.Token.Color.Equals(ruleset.Color));
            }

            if (ruleset == null || !ruleset.VerfiyRuleset(slotTuple, rulesetTuple))
            {
                wrongTokens.Add(slot.Color);
            }
        }

        Debug.Log(wrongTokens.Count);

        return wrongTokens;
    }

    //ToDo
    //Needs to be refactor, this should not be in Gameboard
    private static void HandleChainedRulesets(List<Slot> gameplanState, ref Ruleset ruleset)
    {
        var inverseRuleset = ruleset.RulesetType == enRulesetType.CONTRARY_OF;

        while (ruleset.RulesetType == enRulesetType.SAME_AS || ruleset.RulesetType == enRulesetType.CONTRARY_OF)
        {
            var rulesetColor = ruleset.Color;
            var linkedSlot = gameplanState.FirstOrDefault(slot => slot.Color == rulesetColor);

            if (linkedSlot != null)
            {
                ruleset = linkedSlot.RuleCard.Ruleset;

                inverseRuleset = inverseRuleset != (ruleset.RulesetType == enRulesetType.CONTRARY_OF);

                if (linkedSlot.Color == ruleset.Color || ruleset.RulesetType == enRulesetType.NO_PREFERENCE)
                {
                    break;
                }
            }
            else
            {
                inverseRuleset = false;
                ruleset = null;
                break;
            }
        }

        if (inverseRuleset)
        {
            ruleset.RulesetLogic = new InverseRuleset(ruleset.RulesetLogic);
        }
    }
    #endregion
    #endregion
}
