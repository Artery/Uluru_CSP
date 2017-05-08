using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class represents one Token, each Player will have 7
//Each Token has to be placed on one unique Position
public class Token : UIButtonBase
{
    [SerializeField]
    private Color m_color;

    [SerializeField]
    private UnityEngine.Color m_UIColor;

    public UnityEngine.Color UIColor
    {
        get
        {
            return m_UIColor;
        }

        set
        {
            m_UIColor = value;
        }
    }

    public Color Color
    {
        get { return m_color; }
        set { m_color = value; }
    }

    

    public Token(Color color)
    {
        this.Color = color;
    }
}
