using System;
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
    private Gameboard m_gameboard;
    [SerializeField]
    private List<Token> m_tokens;

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
    public List<Token> Tokens
    {
        get { return m_tokens; }
    }

    public void Unlock()
    {
        throw new NotImplementedException();
    }

    public void Lock()
    {
        throw new NotImplementedException();
    }
}
