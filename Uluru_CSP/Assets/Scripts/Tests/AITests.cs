using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Class summary goes here...
/// </summary>
public class AITests : MonoBehaviour
{
    #region Fields
    #region SerializedFields

    [SerializeField]
    private Game Game;
    #endregion

    public static AITests Instance;

    private static StreamWriter file = new System.IO.StreamWriter("Testlogs\\BacktrackingTests_" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".txt");

    private static readonly List<IBacktrackingAlgorithm> BacktrackingAlgorithms = new List<IBacktrackingAlgorithm>
    {
        new Backtracking_v1(),
        new Backtracking()
    };

    private static bool TestsStarted = false;

    private static Dictionary<String, Dictionary<String, List<int>>> ResultDict = new Dictionary<String, Dictionary<String, List<int>>>();
    #endregion

    #region Properties
    #endregion

    #region Methods

    #region MonoMethods

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ExecuteTests();
    }

    void Update()
    {
        if(Instance.Game.m_GameFinished && TestsStarted == true)
        {
            file.Close();
            TestsStarted = false;
        }
    }

    #endregion
    #region StaticMethods

    private static List<IBacktrackingAlgorithm> GetBacktrackingAlgorithms() => new List<IBacktrackingAlgorithm> {new Backtracking_v1(), new Backtracking()};

    public static void ExecuteTests()
    {
        TestsStarted = true;
        var TestCases = new List<Func<DeckGenerator.enRuleCardColors, RuleCard>>
                        {
                            TestDecksLibrary.CreateTestNo_1,
                            TestDecksLibrary.CreateTestNo_2,
                            TestDecksLibrary.CreateTestNo_3
                        };

        ResultDict = new Dictionary<String, Dictionary<String, List<int>>>();

        /*foreach (var ba in BacktrackingAlgorithms)
        {
            var testCaseDict = new Dictionary<string, List<int>>();
            TestCases.ForEach(tc => testCaseDict.Add());
        }

        BacktrackingAlgorithms.ForEach(ba => ResultDict.Add(ba.Version, 
            new Dictionary<string, List<int>>));*/

        Instance.Game.IsInTestMode = true;
        Instance.Game.CreateTestDecks = true;
        Instance.Game.MaxRounds = TestCases.Count;
        Instance.Game.TestCases = TestCases;
        Instance.Game.StartNewGame();

        file.WriteLine("Backtracking Test Squence - " + DateTime.Now.ToString("dd.MM.yyyy HH.mm.ss") + "\n\n");
    }

    public static void ExecuteBacktrackingTests(Player player, List<Slot> gameplanState)
    {
        var csp = "Gameplanstate:\n";
        gameplanState.ForEach(slot => csp += slot.Color + ":\t" + slot.RuleCard.Color + " \t" + slot.RuleCard.RulesetType.ToString() + "\n" );
        Debug.Log(csp);
        file.WriteLine(csp);

        foreach (var algorithm in BacktrackingAlgorithms)
        {
            ExecuteSingeBacktrackingAlgorithm(file, player, gameplanState, algorithm);
        }

        var delimiter = "------------------------------------------------------------------------------------------------------\n";
        Debug.Log(delimiter);
        file.WriteLine(delimiter);
    }

    private static void ExecuteSingeBacktrackingAlgorithm(StreamWriter file, Player player, List<Slot> gameplanState, IBacktrackingAlgorithm algorithm)
    {
        var header = algorithm.Version;
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
