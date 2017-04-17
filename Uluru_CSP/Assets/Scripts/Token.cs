using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents one Token, each Player will have 7
//Each Token has to be placed on one unique Position
public class Token
{
    public Color Color { get; set; }
    public Position Position { get; set; }

    public Token(Color color, Position position = null)
    {
        this.Color = color;
        this.Position = position;
    }
}
