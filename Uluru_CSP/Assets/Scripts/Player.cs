using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents one player 
public class Player : MonoBehaviour
{
    [SerializeField]
    private string m_PlayerName;
    [SerializeField]
    private int m_Drawback;
    [SerializeField]
    private Gameboard m_Gameboard;
    [SerializeField]
    private List<Token> m_Tokens;

    public string Name
    {
        get { return m_PlayerName; }
        set { m_PlayerName = value; }
    }
    public int Drawback
    {
        get { return m_Drawback; }
        set { m_Drawback = value; }
    }
    public Gameboard Gameboard
    {
        get { return m_Gameboard; }
        set { m_Gameboard = value; }
    }
    public List<Token> Tokens
    {
        get { return m_Tokens; }
    }

    public void Unlock()
    {
        ChangeUnlockTo(true);
    }

    public void Lock()
    {
        ChangeUnlockTo(false);
    }

    private void ChangeUnlockTo(bool isUnlocked)
    {
        Gameboard.IsUnlocked = isUnlocked;
        Tokens.ForEach(token => token.IsUnlocked = isUnlocked);
    }
}
