﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Backtracking
{
    public static List<PositionTokenTuple> BacktrackingSearch(List<PositionTokenTuple> assignment, List<Slot> csp, List<Token> tokens)
    {
        return RecursiveBacktracking(assignment, csp, tokens);
    }

    private static int counter = 0;
    public static int loopCounter = 0;

    private static List<PositionTokenTuple> RecursiveBacktracking(List<PositionTokenTuple> assignment, List<Slot> csp, List<Token> tokens)
    {
        if (counter >= 10000)
        {
            Debug.Log("INFINITE LOOP");
            //solution
            return null;
        }
        
        Debug.Log("Loop: " + counter++);

        if (!tokens.Any())
        {
            Debug.Log("SOLUTION");
            //solution
            return assignment;
        }

        //What variable should be assigned next?
        var var = SelectUnassignedVariable(csp, tokens);
        Debug.Log("Var(-color): " + var.Color);
        //In what order should values be tried for a variable
        var orderDomainValues = OrderDomainValues(var, assignment, csp);
        var acc = "";
        orderDomainValues.ForEach(tuple => acc += tuple.Position.Index + ", ");

        Debug.Log(var.Color + " - orderDomainValues: " + acc);

        foreach (var value in orderDomainValues)
        {
            loopCounter++;
            Debug.Log(value.Position.Index);
            value.Token = var;

            //if value is consistent with assignment given Constraints[csp]
            if (IsValueConsistentWithAssignmentGivenContraints(assignment, csp))
            {
                Debug.Log(var.Color + " - Consistent == true");
                //add {var = value} to assignment
                assignment = AddValueToAssignment(assignment, value);
                tokens.RemoveAt(0);
                Debug.Log(tokens.Count);
                List<PositionTokenTuple> result = RecursiveBacktracking(assignment, csp, tokens);
                
                if (result != null)
                {
                    Debug.Log(var.Color + " - result != null");
                    return result;

                    //if (IsValueConsistentWithAssignmentGivenContraints(value, assignment, csp,
                    //    csp.FirstOrDefault(slot => slot.Color.Equals(var.Color))))
                    //{

                    //}
                    //Debug.Log(tokens.Count);
                    //Debug.Log(var.Color + " - Rule violation in children");
                }

                Debug.Log(var.Color + " - result == null, removing value");
                //remove {var = value} from assignment
                assignment = RemoveValueFromAssignment(assignment, value);
                value.Token = null;
            }
            else
            {
                Debug.Log(var.Color + " - Consistent == false");
                value.Token = null;
            }
        }

        Debug.Log(var.Color + " - FAILURE");
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

    private static List<PositionTokenTuple> OrderDomainValues(Token var, List<PositionTokenTuple> assignment, List<Slot> csp)
    {
        //ToDo
        //Temp hack
        return assignment.Where(tuple => tuple.Token == null).ToList();
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
