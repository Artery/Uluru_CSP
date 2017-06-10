using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class summary goes here...
/// </summary>
public class UIGameboard : Gameboard
{
    #region Enums
    private enum enButtonType { NONE = -1, POSITION = 0, TOKEN = 1 };
    #endregion

    #region Fields
    #region SerializedFields
    #endregion
    private GameObject m_LastSelectedButton = null;
    private enButtonType m_LastSelectedButtonType = enButtonType.NONE;
    #endregion

    #region Properties
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
    public void PositionButtonClicked(GameObject clickedButton)
    {
        ButtonClicked(clickedButton, enButtonType.POSITION);
    }

    public void TokenButtonClicked(GameObject clickedButton)
    {
        ButtonClicked(clickedButton, enButtonType.TOKEN);
    }

    public override void Clear()
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

        UnityEngine.Color? tokenColor = token?.UIColor;

        tokenPositionTuple.Position.UpdateTokenImageColor(tokenColor);
    }
    #endregion
    #endregion
}
