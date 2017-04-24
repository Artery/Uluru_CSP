﻿using UnityEngine;
using System.Linq;
using System.Collections;

public class Game : MonoBehaviour
{
    #region Attributes
    [SerializeField]
    private Gameplan m_gameplan = new Gameplan();
    [SerializeField]
    private Hourglass m_hourglass = new Hourglass();

    [SerializeField]
    private Difficulty m_difficulty;
    [SerializeField]
    private int m_maxRounds;
    [SerializeField]
    private int m_currentRound;

    [SerializeField]
    private PlayerCollection m_players = new PlayerCollection();
    [SerializeField]
    private Difficulty_CardCollectionMap m_deck = new Difficulty_CardCollectionMap();
    #endregion

    #region Getter/Setter/Properties
    public PlayerCollection Players
    {
        get { return m_players; }
    }

    public Difficulty_CardCollectionMap Deck
    {
        get { return m_deck; }
    }

    public Gameplan Gameplan
    {
        get { return m_gameplan; }
    }

    public Hourglass Hourglass
    {
        get { return m_hourglass; }
    }

    public Difficulty Difficulty
    {
        get { return m_difficulty; }
        set { m_difficulty = value; }
    }
    public int MaxRounds
    {
        get { return m_maxRounds; }
        set { m_maxRounds = value; }
    }
    public int CurrentRound
    {
        get { return m_currentRound; }
        set { m_currentRound = value; }
    }
    #endregion

    #region GameMethods

    //Loop for an active Game
    public IEnumerator GameLoop()
    {
        while(CurrentRound <= MaxRounds)
        {
            InitializeRound();
            StartRound();
            yield return new WaitUntil(() => Hourglass.Finished);
            FinishRound();
        }

        FinishGame();
    }

    //Prepares a game for being started
    protected void InitializeGame()
    {
        ClearGameState();

        CurrentRound = 1;
        Gameplan.Intialize(SelectGameDeck());
    }

    protected void ClearGameState()
    {
        CurrentRound = 0;

        ResetRoundState();
        Gameplan.Clear();
        ResetPlayerDrawbacks();
    }

    //Starts a Game by starting it's GameLoop
    protected void StartGame()
    {
        StartCoroutine(GameLoop());
    }

    protected void FinishGame()
    {
        ResetRoundState();
        DeclareWinner();
    }

    protected void DeclareWinner()
    {
        var winner = Players.OrderByDescending(player => player.Drawback).FirstOrDefault();
    }
    #endregion

    #region RoundMethods
    //Prepares a round for being started
    protected void InitializeRound()
    {
        Gameplan.GenerateSequence();
        ResetPlayerGameboards();
    }
    
    protected void StartRound()
    {
        Gameplan.DealOutNextSequence();
        UnlockPlayers();
        Hourglass.Start();
    }

    protected void FinishRound()
    {
        LockPlayers();
        EvaluatePlayersScore();
        //ToDo Timer which waits here, 
        //so the visual feedback has time to be applied
        ResetPlayerGameboards();
        CurrentRound++;
    }

    protected void ResetRoundState()
    {
        Hourglass.Reset(false);
        Gameplan.Reset();
        ResetPlayerGameboards();
    }
    #endregion

    #region PlayerMethods
    protected void ResetPlayerGameboards()
    {
        Players.ForEach(player => player.Gameboard.Reset());
    }

    protected void ResetPlayerDrawbacks()
    {
        Players.ForEach(player => player.Drawback = 0);
    }

    protected void UnlockPlayers()
    {
        Players.ForEach(player => player.Unlock());
    }

    protected void LockPlayers()
    {
        Players.ForEach(player => player.Lock());
    }

    protected void VerifyPlayerGameboards()
    {

    }
    #endregion

    #region DeckMethods
    protected CardCollection SelectGameDeck()
    {
        return new CardCollection(Deck.Where(pair => pair.Key <= Difficulty).SelectMany(pair => pair.Value));
    }
    #endregion
}
