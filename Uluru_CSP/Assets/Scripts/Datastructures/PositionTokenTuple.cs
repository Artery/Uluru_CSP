using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class summary goes here...
/// </summary>
[System.Serializable]
public class PositionTokenTuple
{
    #region Fields
    #region SerializedFields
    [SerializeField]
    private Position m_Position;
    [SerializeField]
    private Token m_Token;
    #endregion
    #endregion

    #region Properties
    public Position Position
    {
        get { return m_Position; }
        set { m_Position = value; }
    }

    public Token Token
    {
        get { return m_Token; }
        set { m_Token = value; }
    }
    #endregion

    #region Constructors
    public PositionTokenTuple(Position position, Token token)
    {
        Position = position;
        Token = token;
    }
    #endregion

    #region Methods
    #region ClassMethods
    #endregion
    #endregion 
}

