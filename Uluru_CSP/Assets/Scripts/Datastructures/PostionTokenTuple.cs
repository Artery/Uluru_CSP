using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTokenTuple
{ 
    public Position Postion { get; set; }
    public Token Token { get; set; }

    public PositionTokenTuple(Position position, Token token)
    {
        Postion = position;
        Token = token;
    }
}
