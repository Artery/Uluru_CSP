using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private string m_name;
    [SerializeField]
    private int m_drawback;
    [SerializeField]
    private Gameboard m_gameboard = new Gameboard();
    [SerializeField]
    private TokenCollection m_tokens = new TokenCollection();

    public string Name
    {
        get { return m_name; }
        set { m_name = value; }
    }
    public int Drawback
    {
        get { return m_drawback; }
        set { m_drawback = value; }
    }
    public Gameboard Gameboard
    {
        get { return m_gameboard; }
        set { m_gameboard = value; }
    }
    public TokenCollection Tokens
    {
        get { return m_tokens; }
    }
}
