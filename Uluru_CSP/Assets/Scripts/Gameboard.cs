using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameboard : MonoBehaviour
{
    private enum enButtonType { NONE = -1, POSITION, TOKEN };

    [SerializeField]
    private List<PositionTokenTuple> m_positionsTokens;
    [SerializeField]
    private bool m_IsUnlocked = false;

    private GameObject m_LastSelectedButton = null;
    private enButtonType m_LastSelectedButtonType = enButtonType.NONE;

    public List<PositionTokenTuple> PositionsTokens
    {
        get
        {
            return m_positionsTokens;
        }
    }

    public PositionCollection Positions
    {
        get
        {
            return new PositionCollection(m_positionsTokens.Select(tuple => tuple.Position));
        }
    }

    public TokenCollection Tokens
    {
        get
        {
            return new TokenCollection(m_positionsTokens.Select(tuple => tuple.Token));
        }
    }

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


    public void Reset()
    {
        //m_positionsTokens.ForEach(tuple => tuple.Token = null);
        Positions.ForEach(position => SetTokenOnPosition(null, position));
    }

    public List<Color> VerifyBoardState(List<Slot> gameplanState)
    {
        var wrongTokens = new List<Color>();

        foreach (var slot in gameplanState)
        {
            Debug.Log(slot.Color);
            PositionTokenTuple rulesetTuple = null;
            var slotTuple = m_positionsTokens.FirstOrDefault(tuple => tuple.Token != null && tuple.Token.Color.Equals(slot.Color));
            var ruleset = slot.RuleCard.Ruleset;

            var yo = slot.RuleCard.RulesetType;
            var negate = yo == enRulesetType.OPPOSITEOF;

            while (yo == enRulesetType.SAMEAS || yo == enRulesetType.OPPOSITEOF)
            {
                var __slot = gameplanState.FirstOrDefault(_slot => _slot.Color == ruleset.Color);
                ruleset = __slot.RuleCard.Ruleset;
                yo = __slot.RuleCard.RulesetType;

                negate = negate != (yo == enRulesetType.OPPOSITEOF);

                if (__slot.Color == ruleset.Color || __slot.RuleCard.RulesetType == enRulesetType.IDONTKNOW)
                {
                    break;
                }
            }

            if (negate)
            {
                ruleset.RulesetLogic = new Inverse(ruleset.RulesetLogic);
            }


            if (!ruleset.Color.Equals(Color.NONE))
            {
                rulesetTuple = m_positionsTokens.FirstOrDefault(tuple => tuple.Token != null && tuple.Token.Color.Equals(ruleset.Color));
            }

            if (!ruleset.VerfiyRuleset(slotTuple, rulesetTuple))
            {
                wrongTokens.Add(slot.Color);
            }
        }

        Debug.Log(wrongTokens.Count);

        return wrongTokens;
    }

    public void PositionButtonClicked(GameObject clickedButton)
    {
        ButtonClicked(clickedButton, enButtonType.POSITION);
    }

    public void TokenButtonClicked(GameObject clickedButton)
    {
        ButtonClicked(clickedButton, enButtonType.TOKEN);
    }

    private void ButtonClicked(GameObject clickedButton, enButtonType clickedButtonType)
    {
        if (m_LastSelectedButton == null || m_LastSelectedButtonType == clickedButtonType)
        {
            m_LastSelectedButton = clickedButton;
            m_LastSelectedButtonType = clickedButtonType;
        }
        else if (m_LastSelectedButton != null && clickedButton != null)
        {
            var token = m_LastSelectedButtonType == enButtonType.TOKEN ? m_LastSelectedButton.GetComponent<Token>() : clickedButton.GetComponent<Token>();
            var position = m_LastSelectedButtonType == enButtonType.POSITION ? m_LastSelectedButton.GetComponent<Position>() : clickedButton.GetComponent<Position>();

            SetTokenOnPosition(token, position);

            m_LastSelectedButton = null;
            m_LastSelectedButtonType = enButtonType.NONE;
        }
    }

    public void SetTokenOnPosition(Token token, Position position)
    {
        if(token != null)
        {
            var oldPosition = m_positionsTokens.Where(tuple => token.Equals(tuple.Token)).FirstOrDefault();

            if (oldPosition != null)
            {
                oldPosition.Token = null;
                oldPosition.Position.UpdateTokenImageColor(null);
            }
        }
        
        var tokenPositionTuple = m_positionsTokens.Single(tuple => position.Equals(tuple.Position));

        tokenPositionTuple.Token = token;

        UnityEngine.Color? tokenColor = null;
        if (token != null) { tokenColor = token.UIColor; }

        tokenPositionTuple.Position.UpdateTokenImageColor(tokenColor);
    }

}
