using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class represents one Token, each Player will have 7
//Each Token has to be placed on one unique Position
public class Token : MonoBehaviour
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

    [SerializeField]
    private Button m_Button;

    public Button Button
    {
        get
        {
            return m_Button;
        }

        protected set
        {
            m_Button = value;
        }
    }

    [SerializeField]
    private bool m_IsUnlocked = false;

    public bool IsUnlocked
    {
        get
        {
            return m_IsUnlocked;
        }

        set
        {
            if (m_IsUnlocked != value)
            {
                m_IsUnlocked = value;

                m_Button.interactable = m_IsUnlocked;
            }
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
