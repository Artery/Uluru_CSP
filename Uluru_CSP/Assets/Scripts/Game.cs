﻿using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

//Main class handling the Game and the Game-Loop
public class Game : MonoBehaviour
{
    #region Attributes
    [SerializeField]
    private Gameplan m_Gameplan;
    [SerializeField]
    private Hourglass m_Hourglass;

    [SerializeField]
    private Difficulty m_Difficulty;
    [SerializeField]
    private int m_MaxRounds;
    [SerializeField]
    private int m_CurrentRound;

    [SerializeField]
    private List<Player> m_Players;

    [SerializeField]
    private Scoreboard m_Scoreboard;
    #endregion

    #region Getter/Setter/Properties
    public List<Player> Players
    {
        get { return m_Players; }
    }

    public Gameplan Gameplan
    {
        get { return m_Gameplan; }
    }

    public Hourglass Hourglass
    {
        get { return m_Hourglass; }
    }

    public Difficulty Difficulty
    {
        get { return m_Difficulty; }
        set { m_Difficulty = value; }
    }
    public int MaxRounds
    {
        get { return m_MaxRounds; }
        set { m_MaxRounds = value; }
    }
    public int CurrentRound
    {
        get { return m_CurrentRound; }
        set { m_CurrentRound = value; }
    }
    #endregion

    #region MonoMethods
    void Start()
    {
        InitializeGame();
        StartGame();
    }

    void Update()
    {
        //ToDo
        //Should be refactored, when Scoreboard is standalone feature
        m_Scoreboard.UpdateRemainingTime(Hourglass.RemainingTime);
    }
    #endregion

    #region GameMethods

    //Game-Loop for an active Game
    public IEnumerator GameLoop()
    {
        while(CurrentRound < MaxRounds)
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
        CurrentRound = 0;

        InitializePlayersScoreboard();
        InitializeGameplan();
        LockPlayers();
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
        CurrentRound++;
        Hourglass.Reset();
        Gameplan.GenerateSequence();
        ResetPlayerGameboards();
        UpdatePlayersScoreboard();
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
        //ResetPlayerGameboards();
        UpdatePlayersScoreboard();
    }

    protected void ResetRoundState()
    {
        Hourglass.Reset(false);
        //Gameplan.Reset();
        //ResetPlayerGameboards();
    }
    #endregion

    #region PlayerMethods
    protected void InitializePlayersScoreboard()
    {
        //ToDo
        //Temp hack
        m_Scoreboard.NameField.text = "Artery";
        m_Scoreboard.RoundField.text = CurrentRound + "/" + MaxRounds;
    }

    protected void UpdatePlayersScoreboard()
    {
        //ToDo
        //Temp hack
        m_Scoreboard.DrawbackField.text = Players.First().Drawback.ToString();
        m_Scoreboard.RoundField.text = CurrentRound + "/" + MaxRounds;
    }

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

    protected void EvaluatePlayersScore()
    {
        var gameplanState = Gameplan.Slots;
        foreach(var player in Players)
        {
            //ToDo
            //temp hack

            //Old V1
            Debug.Log("------------------------------------------------------------------------------------------------------\n"
                      + Backtracking_v1.Version);
            //Debug.Log(Backtracking.Version);

            var tokens = new List<Token>();
            tokens.AddRange(player.Tokens);
            player.Gameboard.Reset();

            var result = Backtracking_v1.BacktrackingSearch(player.Gameboard.PositionsTokens, gameplanState, tokens);
            var resultOutput = "";

            result.ForEach(
                tuple => resultOutput += "Index: " + tuple.Position.Index + "::Token: " + tuple.Token.Color + "\n");
            Debug.Log(resultOutput);
            Debug.Log("Loop: " + Backtracking_v1.counter + "\nLoopCounter: " + Backtracking_v1.loopCounter);
            //Debug.Log("LoopCounter: " + Backtracking.loopCounter);

            player.Gameboard.PositionsTokens = result;
            player.Drawback -= player.Gameboard.VerifyBoardState(gameplanState).Count;
            Debug.Log("Wrong Tokens: " + player.Drawback * -1
                      + "\n------------------------------------------------------------------------------------------------------");


            //Current Version V2
            Debug.Log("------------------------------------------------------------------------------------------------------\n" 
                + Backtracking.Version);
            //Debug.Log(Backtracking.Version);

            tokens = new List<Token>();
            tokens.AddRange(player.Tokens);
            player.Gameboard.Reset();

            result = Backtracking.BacktrackingSearch(player.Gameboard.PositionsTokens, gameplanState, tokens);
            resultOutput = "";

            result.ForEach(
                tuple => resultOutput += "Index: " + tuple.Position.Index + "::Token: " + tuple.Token.Color + "\n");
            Debug.Log(resultOutput);
            Debug.Log("Loop: " + Backtracking.counter + "\nLoopCounter: " + Backtracking.loopCounter);
            //Debug.Log("LoopCounter: " + Backtracking.loopCounter);

            player.Gameboard.PositionsTokens = result;
            player.Drawback -= player.Gameboard.VerifyBoardState(gameplanState).Count;
            Debug.Log("Wrong Tokens: " + player.Drawback*-1 
                + "\n------------------------------------------------------------------------------------------------------");

            //ToDo visualize Round result for each player
            //Includes visualizing correct and wrong placed Tokens
            //and showing applied drawbacks of and for all players
            //e.g. gameboard.VisualizeRoundResult(result);
        }
    }
    #endregion

    #region GameplanMethods
    protected void InitializeGameplan()
    {
        Gameplan.Intialize(DeckGenerator.GenerateDeck(Difficulty));
    }
    #endregion
}
