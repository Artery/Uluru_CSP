using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameboard : Gameboard
{
    private enum enButtonType { NONE = -1, POSITION, TOKEN };

    private GameObject m_LastSelectedButton = null;
    private enButtonType m_LastSelectedButtonType = enButtonType.NONE;

    public void PositionButtonClicked(GameObject clickedButton)
    {
        ButtonClicked(clickedButton, enButtonType.POSITION);
    }

    public void TokenButtonClicked(GameObject clickedButton)
    {
        ButtonClicked(clickedButton, enButtonType.TOKEN);
    }

    public override void Reset()
    {
        Positions.ForEach(position => SetTokenOnPosition(null, position));
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
        if (token != null)
        {
            var oldPosition = PositionsTokens.FirstOrDefault(tuple => token.Equals(tuple.Token));

            if (oldPosition != null)
            {
                oldPosition.Token = null;
                oldPosition.Position.UpdateTokenImageColor(null);
            }
        }

        var tokenPositionTuple = PositionsTokens.Single(tuple => position.Equals(tuple.Position));

        tokenPositionTuple.Token = token;

        UnityEngine.Color? tokenColor = null;
        if (token != null) { tokenColor = token.UIColor; }

        tokenPositionTuple.Position.UpdateTokenImageColor(tokenColor);
    }
}
