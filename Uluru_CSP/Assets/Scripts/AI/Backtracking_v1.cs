using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Backtracking_v1 : IBacktrackingAlgorithm
{
    public string Version { get; set; } = "Version 1 - MRV+Degree & SimpleLCV";

    public int Loop { get; set; } = 0;
    public int LoopCounter { get; set; } = 0;

    private static int counter = 0;
    private static int loopCounter = 0;

    private static readonly Dictionary<enRulesetType, List<int>> reducedPoistionsByRule = new Dictionary<enRulesetType, List<int>>
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

    private static readonly List<enRulesetType> mrv = new List<enRulesetType>
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
        degree = new Dictionary<Color, int>
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

        counter = 0;
        loopCounter = 0;
        Loop = 0;
        LoopCounter = 0;

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

        tokens.Sort((x, y) => CompareMRV(x, y, csp));
        string yo = "";
        tokens.ForEach(x => yo += x.Color + ", ");
        //Debug.Log(yo);

        //return null;

        //InitializeBacktrackingSearch(ref assignment, ref csp, ref tokens);
        return RecursiveBacktracking(assignment, csp, tokens);
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
        var var = SelectUnassignedVariable(csp, tokens);
        //Debug.Log("Var(-color): " + var.Color);
        //In what order should values be tried for a variable
        var orderDomainValues = OrderDomainValues(var, assignment, csp, tokens.Where(t => !t.Equals(var)).ToList());
        var acc = "";
        orderDomainValues.ForEach(tuple => acc += tuple.Position.Index + ", ");

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

    private static Token SelectUnassignedVariable(List<Slot> csp, List<Token> tokens)
    {
        //ToDo
        //Temp hack
        return tokens.First();
    }

    private static List<PositionTokenTuple> OrderDomainValues(Token var, List<PositionTokenTuple> assignment, List<Slot> csp, List<Token> tokens)
    {
        //ToDo
        //Temp hack
        var yo = reducedPoistionsByRule[csp.Single(s => s.Color.Equals(var.Color)).RuleCard.RulesetType];
        var pos = assignment.Where(tuple => tuple.Token == null && yo.Contains(tuple.Position.Index)).ToList();
        //var ass = assignment.Where(tuple => tuple.Token == null && yo.Contains(tuple.Position.Index)).ToList();

        var restPos = new Dictionary<int, int>();

        foreach (var p in pos)
        {
            restPos.Add(p.Position.Index, 0);
            foreach (var t in tokens)
            {
                //restPos[p.Position.Index] 
                var yoo = reducedPoistionsByRule[csp.Single(s => s.Color.Equals(t.Color)).RuleCard.RulesetType];
                var rp = assignment.Where(tuple => tuple.Token == null && yoo.Contains(tuple.Position.Index)).ToList();
                if (rp.Contains(p))
                {
                    restPos[p.Position.Index]++;
                }
            }
            //Debug.Log(p.Position.Index + " :: " + restPos[p.Position.Index]);
        }

        pos.Sort((x, y) => restPos[x.Position.Index] - restPos[y.Position.Index]);

        return pos;

        //var yo = reducedPoistionsByRule[csp.Single(s => s.Color.Equals(var.Color)).RuleCard.RulesetType];
        //return assignment.Where(tuple => tuple.Token == null && yo.Contains(tuple.Position.Index)).ToList();
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
