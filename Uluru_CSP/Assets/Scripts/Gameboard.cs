using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameboard : MonoBehaviour
{
    [SerializeField]
    private PositionTokenTupleCollection m_positionsTokens = new PositionTokenTupleCollection();

    public PositionTokenTupleCollection PositionsTokens
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
            return new PositionCollection(m_positionsTokens.Select(tuple => tuple.Postion));
        }
    }

    public TokenCollection Tokens
    {
        get
        {
            return new TokenCollection(m_positionsTokens.Select(tuple => tuple.Token));
        }
    }

    public void Reset()
    {
        m_positionsTokens.ForEach(tuple => tuple.Token = null);
    }
}
