using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class represents one Token, each Player will have 7
//Each Token has to be placed on one unique Position
public class Token : MonoBehaviour
{
    [SerializeField]
    private Color m_color;
    [SerializeField]
    private Position m_position;

    public Color Color
    {
        get { return m_color; }
        set { m_color = value; }
    }
    public Position Position
    {
        get { return m_position; }
        set { m_position = value; }
    }

    public Token(Color color, Position position = null)
    {
        this.Color = color;
        this.Position = position;
    }
}
