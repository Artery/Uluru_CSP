using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Backtracking
{
    public List<PositionTokenTuple> BacktrackingSearch(List<PositionTokenTuple> assignment, List<Slot> csp, List<Token> tokens)
    {
        return RecursiveBacktracking(assignment, csp, tokens);
    }

    private List<PositionTokenTuple> RecursiveBacktracking(List<PositionTokenTuple> assignment, List<Slot> csp, List<Token> tokens)
    {
        if (!tokens.Any())
        {
            //solution
            return assignment;
        }

        //What variable should be assigned next?
        var var = SelectUnassignedVariable(csp, tokens);
        //In what order should values be tried for a variable
        var orderDomainValues = OrderDomainValues(var, assignment, csp);

        foreach (var value in orderDomainValues)
        {
            if (IsValueConsistentWithAssignmentGivenContraints(value, assignment, csp))
            {
                //add {var = value} to assignment
                assignment = AddValueToAssignment(assignment, value);

                var result = RecursiveBacktracking(assignment, csp, tokens);

                if (result != null)
                {
                    return result;
                }

                //remove {var = value} from assignment
                assignment = RemoveValueFromAssignment(assignment, value);
            }
        }

        //failure
        return null;
    }

    private Token SelectUnassignedVariable(List<Slot> csp, List<Token> tokens)
    {
        //ToDo
        //Temp hack
        return tokens.First();
    }

    private IEnumerable<PositionTokenTuple> OrderDomainValues(Token var, List<PositionTokenTuple> assignment, List<Slot> csp)
    {
        //ToDo
        //Temp hack
        return null;
    }

    private bool IsValueConsistentWithAssignmentGivenContraints(PositionTokenTuple tuple, List<PositionTokenTuple> assignment, List<Slot> csp)
    {
        //ToDo
        //Temp hack
        return false;
    }

    private List<PositionTokenTuple> AddValueToAssignment(List<PositionTokenTuple> assignment, PositionTokenTuple value)
    {
        //ToDo
        //Temp hack
        assignment.Single(tuple => tuple.Position.Equals(value.Position)).Token = value.Token;
        return assignment;
    }

    private List<PositionTokenTuple> RemoveValueFromAssignment(List<PositionTokenTuple> assignment, PositionTokenTuple value)
    {
        //ToDo
        //Temp hack
        assignment.Single(tuple => tuple.Position.Equals(value.Position)).Token = null;
        return assignment;
    }
}
