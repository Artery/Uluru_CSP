using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private TokenCollection m_tokens = new TokenCollection();

    public string Name { get; set; }
    public int Drawback { get; set; }
    public Gameboard Gameboard { get; set; }
    public TokenCollection Tokens
    {
        get
        {
            return m_tokens;
        }
     }
}
