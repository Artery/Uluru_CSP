using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PositionTokenTuple
{
    [SerializeField]
    private Position m_Position;
    [SerializeField]
    private Token m_Token;

    public PositionTokenTuple(Position position, Token token)
    {
        Position = position;
        Token = token;
    }

    public Position Position
    {
        get
        {
            return m_Position;
        }

        set
        {
            m_Position = value;
        }
    }

    public Token Token
    {
        get
        {
            return m_Token;
        }

        set
        {
            m_Token = value;
        }
    }
}

