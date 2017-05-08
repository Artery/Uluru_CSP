using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTokenTuple
{ 
    public Position Position { get; set; }
    public Token Token { get; set; }

    public PositionTokenTuple(Position position, Token token)
    {
        Position = position;
        Token = token;
    }
}
