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

    public bool IsUnlocked { get; set; }

    public void Reset()
    {
        m_positionsTokens.ForEach(tuple => tuple.Token = null);
    }

    public List<Color> VerifyBoardState(Color_CardMap gameplanState)
    {
        var wrongTokens = new List<Color>();

        foreach(var color_card in gameplanState)
        {
            PositionTokenTuple rulesetTuple = null;
            var slotTuple = m_positionsTokens.FirstOrDefault(tuple => tuple.Token != null && tuple.Token.Color.Equals(color_card.Key));
            var ruleset = color_card.Value.Ruleset;

            if (!ruleset.Color.Equals(Color.NONE))
            {
                rulesetTuple = m_positionsTokens.FirstOrDefault(tuple => tuple.Token != null && tuple.Token.Color.Equals(ruleset.Color));
            }

            if(!ruleset.VerfiyRuleset(slotTuple, rulesetTuple))
            {
                wrongTokens.Add(color_card.Key);
            }
        }

        return wrongTokens;
    }
}
