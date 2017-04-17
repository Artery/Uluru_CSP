using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token
{
    public Color color { get; set; }
    public Position position { get; set; }

    public Token(Color color, Position position = null)
    {
        this.color = color;
        this.position = position;
    }
}
