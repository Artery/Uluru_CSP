using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Class summary goes here...
/// </summary>
public class AITests
{
    #region Fields
    #region SerializedFields
    #endregion
    private static List<IBacktrackingAlgorithm> Algorithms = new List<IBacktrackingAlgorithm>
    {
        new Backtracking_v1(),
        new Backtracking()
    };
    #endregion

    #region Properties
    #endregion

    #region Methods
    #region StaticMethods

    public static void ExecuteBacktrackingTests(Player player, List<Slot> gameplanState)
    {
        System.IO.StreamWriter file = new System.IO.StreamWriter("Testlogs\\BacktrackingTests_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".txt");

        file.WriteLine("Backtracking Test Squence - " + DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss") + "\n\n");

        var csp = "Gameplanstate:\n";
        gameplanState.ForEach(slot => csp += slot.Color + " \t" + slot.RuleCard.RulesetType.ToString() + "\n");
        Debug.Log(csp);
        file.WriteLine(csp);

        foreach (var algorithm in Algorithms)
        {
            ExecuteSingeBacktrackingAlgorithm(file, player, gameplanState, algorithm);
        }

        file.Close();
    }

    private static void ExecuteSingeBacktrackingAlgorithm(StreamWriter file, Player player, List<Slot> gameplanState, IBacktrackingAlgorithm algorithm)
    {
        var header = "------------------------------------------------------------------------------------------------------\n" + algorithm.Version;
        Debug.Log(header);
        file.WriteLine(header);

        var tokens = new List<Token>();
        tokens.AddRange(player.Tokens);
        player.Gameboard.Reset();

        var result = algorithm.ExecuteAlgorithm(player.Gameboard.PositionsTokens, gameplanState, tokens);
        var resultOutput = "";

        result.ForEach(
            tuple => resultOutput += "Index: " + tuple.Position.Index + "::Token: " + tuple.Token.Color + "\n");
        Debug.Log(resultOutput);
        file.WriteLine(resultOutput);
        var loopOutput = "Loop: " + algorithm.Loop + "\nLoopCounter: " + algorithm.LoopCounter;
        Debug.Log(loopOutput);
        file.WriteLine(loopOutput);

        player.Gameboard.PositionsTokens = result;
        var valResult = player.Gameboard.VerifyBoardState(gameplanState).Count;
        player.Drawback -= player.Gameboard.VerifyBoardState(gameplanState).Count;
        var tail = "Wrong Tokens: " + valResult + "\n------------------------------------------------------------------------------------------------------";
        Debug.Log(tail);
        file.WriteLine(tail);
    }


    #endregion
    #endregion
}
