using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Backtracking : IBacktrackingAlgorithm
{
    public string Version { get; set; } = "Version 2 - MRV+Degree & (LCV)BlockedPositions+SimpleInference";

    public int Loop { get; set; } = 0;
    public int LoopCounter { get; set; } = 0;

    private static int counter = 0;
    private static int loopCounter = 0;

    private static Dictionary<Color, List<int>> remainingTokensPositions = new Dictionary<Color, List<int>>();

    private static Dictionary<enRulesetType, Dictionary<int, List<int>>> linkedBlockedPositions = new Dictionary<enRulesetType, Dictionary<int, List<int>>>()
    {
        { enRulesetType.NO_PREFERENCE, new Dictionary<int, List<int>> {{-1, null}}},
        { enRulesetType.BUMERANG_GROUP, new Dictionary<int, List<int>> {{-1, null}}},
        { enRulesetType.LONLEY_GROUP, new Dictionary<int, List<int>> {{-1, null}}},
        { enRulesetType.LONG_SIDE, new Dictionary<int, List<int>> {{-1, null}}},
        { enRulesetType.SHORT_SIDE, new Dictionary<int, List<int>> {{-1, null}}},
        { enRulesetType.ADJACENT, new Dictionary<int, List<int>>
                                  {
                                      {1, new List<int>() {2}}, {2, new List<int>() {1}}, {3, new List<int>() {4}}, {4, new List<int>() {3}},
                                      {5, new List<int>() {6}}, {6, new List<int>() {5,7}}, {7, new List<int>() {6}}
                                  }},
        { enRulesetType.AROUND_THE_CORNER, new Dictionary<int, List<int>>
                                  {
                                      {0, new List<int>() {1,7}}, {1, new List<int>() {0}}, {2, new List<int>() {3}}, {3, new List<int>() {2}},
                                      {4, new List<int>() {5}}, {5, new List<int>() {4}}, {7, new List<int>() {0}}
                                  }},
        { enRulesetType.OPPOSITE_SIDE, new Dictionary<int, List<int>> {{0, new List<int>() {3,4}}}},
        { enRulesetType.MINIMUM_DISTANCE_2, new Dictionary<int, List<int>> {{-1, null}}},
        { enRulesetType.NOT_ADJACENT_NOT_OPPOSITE_SIDE, new Dictionary<int, List<int>> {{-1, null}}}
    };
    
    private static Dictionary<enRulesetType, List<int>> reducedPoistionsByRules = new Dictionary<enRulesetType, List<int>>
    {
        {enRulesetType.NO_PREFERENCE, new List<int> {0,1,2,3,4,5,6,7}},
        {enRulesetType.BUMERANG_GROUP, new List<int> {3,4,5,6,7}},
        {enRulesetType.LONLEY_GROUP, new List<int> {0,1,2}},
        {enRulesetType.LONG_SIDE, new List<int> {1,2,5,6,7}},
        {enRulesetType.SHORT_SIDE, new List<int> {0,3,4}},
        {enRulesetType.ADJACENT, new List<int> {1,2,3,4,5,6,7}},
        {enRulesetType.AROUND_THE_CORNER, new List<int> {0,1,2,3,4,5,7}},
        {enRulesetType.OPPOSITE_SIDE, new List<int> {0,1,2,3,4,5,6,7}},
        {enRulesetType.MINIMUM_DISTANCE_2, new List<int> {0,1,2,3,4,5,6,7}},
        {enRulesetType.NOT_ADJACENT_NOT_OPPOSITE_SIDE, new List<int> {0,1,2,3,4,5,6,7}}
    };

    private static List<enRulesetType> mrv = new List<enRulesetType>
    {
        enRulesetType.ADJACENT, enRulesetType.AROUND_THE_CORNER, enRulesetType.OPPOSITE_SIDE, enRulesetType.MINIMUM_DISTANCE_2, enRulesetType.SHORT_SIDE,
        enRulesetType.LONLEY_GROUP, enRulesetType.NOT_ADJACENT_NOT_OPPOSITE_SIDE, enRulesetType.BUMERANG_GROUP, enRulesetType.LONG_SIDE, enRulesetType.NO_PREFERENCE
    };

    private static Dictionary<Color, int> degree = new Dictionary<Color, int>
    {
        {Color.WHITE, 0},
        {Color.PINK, 0},
        {Color.YELLOW, 0},
        {Color.ORANGE, 0},
        {Color.RED, 0},
        {Color.GREEN, 0},
        {Color.BLUE, 0},
        {Color.BLACK, 0},
        {Color.NONE, 0}
    };

    public List<PositionTokenTuple> ExecuteAlgorithm(List<PositionTokenTuple> assignment, List<Slot> csp, List<Token> tokens)
    {
        counter = 0;
        loopCounter = 0;
        Loop = 0;
        LoopCounter = 0;
        remainingTokensPositions.Clear();

        var result = BacktrackingSearch(assignment, csp, tokens);
        Loop = counter;
        LoopCounter = loopCounter;
        return result;
    }

    public static List<PositionTokenTuple> BacktrackingSearch(List<PositionTokenTuple> assignment, List<Slot> csp, List<Token> tokens)
    {
        csp.ForEach(s => degree[s.RuleCard.Color]++);

        string yo2 = "";
        foreach (var keyValuePair in degree)
        {
            yo2 += keyValuePair.Key + ": " + keyValuePair.Value + ", ";
        }
        //Debug.Log(yo2);
        var tkkens = new List<Token>();
        tkkens.AddRange(tokens);

        tkkens.Sort((x, y) => CompareMRV(x, y, csp));
        string yo = "";
        tkkens.ForEach(x => yo += x.Color + ", ");
        //Debug.Log(yo);

        foreach (var token in tkkens)
        {
            var list = new List<int>();
            list.AddRange(reducedPoistionsByRules[csp.Single(s => s.Color.Equals(token.Color)).RuleCard.RulesetType]);
            remainingTokensPositions.Add(token.Color, list);
        }

        //return null;

        //InitializeBacktrackingSearch(ref assignment, ref csp, ref tokens);
        return RecursiveBacktracking(assignment, csp, tkkens);
    }

    public static int CompareMRV(Token x, Token y, List<Slot> csp)
    {
        var mrvVal = mrv.IndexOf(csp.Single(s => s.Color.Equals(x.Color)).RuleCard.RulesetType) - mrv.IndexOf(csp.Single(s => s.Color.Equals(y.Color)).RuleCard.RulesetType);
        //Debug.Log(x.Color + " " + mrvVal + " " + y.Color);
        return mrvVal != 0 ? mrvVal : degree[y.Color] - degree[x.Color];
        //return mrvVal;
    }

    private static List<PositionTokenTuple> RecursiveBacktracking(List<PositionTokenTuple> assignment, List<Slot> csp, List<Token> tokens)
    {
        if (counter >= 3000)
        {
            Debug.Log("INFINITE LOOP");
            //solution
            return null;
        }

        counter++;
        //Debug.Log("Loop: " + counter++);

        if (!tokens.Any())
        {
            //Debug.Log("SOLUTION");
            //solution
            return assignment;
        }

        //What variable should be assigned next?
        var var = SelectUnassignedVariable(csp, tokens, assignment);
        //Debug.Log("Var(-color): " + var.Color);
        //In what order should values be tried for a variable
        var orderDomainValues = OrderDomainValues(var, assignment, csp, tokens.Where(t => !t.Equals(var)).ToList());
        var acc = "";
        if (orderDomainValues == null)
        {
            acc = "NULL";
            //Debug.Log(var.Color + " - FAILURE");
            tokens.Add(var);
            return null;
        }
        else
        {
            orderDomainValues.ForEach(tuple => acc += tuple.Position.Index + ", ");
        }

        //Debug.Log(var.Color + " - orderDomainValues: " + acc);

        foreach (var value in orderDomainValues)
        {
            loopCounter++;
            //Debug.Log(value.Position.Index);
            value.Token = var;

            //if value is consistent with assignment given Constraints[csp]
            if (IsValueConsistentWithAssignmentGivenContraints(assignment, csp))
            {
                //Debug.Log(var.Color + " - Consistent == true");
                //add {var = value} to assignment
                assignment = AddValueToAssignment(assignment, value);
                tokens.RemoveAt(0);
                //Debug.Log(tokens.Count);
                List<PositionTokenTuple> result = RecursiveBacktracking(assignment, csp, tokens);

                if (result != null)
                {
                    //Debug.Log(var.Color + " - result != null");
                    return result;
                }

                //Debug.Log(var.Color + " - result == null, removing value");
                //remove {var = value} from assignment
                assignment = RemoveValueFromAssignment(assignment, value);
                value.Token = null;
            }
            else
            {
                //Debug.Log(var.Color + " - Consistent == false");
                value.Token = null;
            }
        }

        //Debug.Log(var.Color + " - FAILURE");
        tokens.Add(var);
        //failure
        return null;
    }

    private static Token SelectUnassignedVariable(List<Slot> csp, List<Token> tokens, List<PositionTokenTuple> assignment)
    {
        //ToDo
        //Temp hack
        var remainingPositions = assignment.Where(tuple => tuple.Token == null).ToList();

        var remainingTokenPos = new Dictionary<Color, int>();

        foreach (var token in tokens)
        {
            var varRuleCard = csp.Single(s => s.Color.Equals(token.Color)).RuleCard;
            var varRulesetType = varRuleCard.RulesetType;
            var reducededPositionsByRule = reducedPoistionsByRules[varRulesetType];
            remainingTokenPos.Add(token.Color, assignment.Where(t => t.Token == null && reducededPositionsByRule.Contains(t.Position.Index)).ToList().Count);
        }

        tokens.Sort((x, y) => tokensCompare(x, y, csp, remainingTokenPos));


        return tokens.First();
    }

    private static int tokensCompare(Token x, Token y, List<Slot> csp, Dictionary<Color, int> remainingTokenPos)
    {
        var xv = remainingTokenPos[x.Color];
        var yv = remainingTokenPos[y.Color];

        var resultXY = xv - yv;

        return resultXY != 0 ? resultXY : CompareMRV(x, y, csp);
    }

    private static List<PositionTokenTuple> OrderDomainValues(Token var, List<PositionTokenTuple> assignment, List<Slot> csp, List<Token> tokens)
    {
        //ToDo
        //Temp hack
        //Get basically possible Positions for token
        var varRuleCard = csp.Single(s => s.Color.Equals(var.Color)).RuleCard;
        var varRulesetType = varRuleCard.RulesetType;
        var reducededPositionsByRule = reducedPoistionsByRules[varRulesetType];
        //possible positions for Token (reducededPositionsByRule & assignment."unset positions")
        var possiblePositionsTuples = assignment.Where(tuple => tuple.Token == null && reducededPositionsByRule.Contains(tuple.Position.Index)).ToList();
        var remainingPositions = assignment.Where(tuple => tuple.Token == null).ToList();
        var numRemainingPositions = remainingPositions.Count;

        var timesPositonBlocked = new Dictionary<int, int>();
        var remainingTokenPos = new Dictionary<int, int>();

        foreach (var tuple in possiblePositionsTuples)
        {
            timesPositonBlocked.Add(tuple.Position.Index, 0);
            remainingTokenPos.Add(tuple.Position.Index, 9999);

            foreach (var token in tokens)
            {
                var tokenRuleCard = csp.Single(s => s.Color.Equals(token.Color)).RuleCard;
                var tokenRulesetType = tokenRuleCard.RulesetType;
                var tokenReducdedPositionsByRule = reducedPoistionsByRules[tokenRulesetType];

                var blockedPositions = GetBlockedPositions(tokenRulesetType, tuple.Position.Index);
                var actualBlockedPositions = remainingPositions.Where(tup => blockedPositions.Contains(tup.Position.Index));
                var numBlockedPositions = actualBlockedPositions.Count();
                //Invalid state
                if ((numBlockedPositions - numRemainingPositions) == 0)
                {
                    return null;
                }
                timesPositonBlocked[tuple.Position.Index] += numBlockedPositions;
            }

            //Debug.Log(tuple.Position.Index + " :: " + timesPositonBlocked[tuple.Position.Index]);
        }

        possiblePositionsTuples.Sort((x, y) => timesPositonBlocked[x.Position.Index] - timesPositonBlocked[y.Position.Index]);

        return possiblePositionsTuples;
    }

    private static List<int> GetBlockedPositions(enRulesetType rulesetType, int position)
    {
        List<int> blockedPositions = new List<int> { position };

        if (linkedBlockedPositions[rulesetType].TryGetValue(position, out var linkedPositions))
        {
            blockedPositions.AddRange(linkedPositions);
        }

        return blockedPositions;
    }

    private static bool IsValueConsistentWithAssignmentGivenContraint(PositionTokenTuple tuple, List<PositionTokenTuple> assignment, List<Slot> csp, Slot slot)
    {
        //ToDo
        //Temp hack
        return Gameboard.VerifySingleSlot(slot, tuple, assignment, csp);
    }

    private static bool IsValueConsistentWithAssignmentGivenContraints(List<PositionTokenTuple> assignment, List<Slot> csp)
    {
        //ToDo
        //Temp hack
        return Gameboard.VerifyTempBoardState(assignment, csp);
    }

    private static List<PositionTokenTuple> AddValueToAssignment(List<PositionTokenTuple> assignment, PositionTokenTuple value)
    {
        //ToDo
        //Temp hack
        assignment.Single(tuple => tuple.Position.Equals(value.Position)).Token = value.Token;
        return assignment;
    }

    private static List<PositionTokenTuple> RemoveValueFromAssignment(List<PositionTokenTuple> assignment, PositionTokenTuple value)
    {
        //ToDo
        //Temp hack
        assignment.Single(tuple => tuple.Position.Equals(value.Position)).Token = null;
        return assignment;
    }
}
