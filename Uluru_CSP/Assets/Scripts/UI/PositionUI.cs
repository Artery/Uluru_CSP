using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositionUI : MonoBehaviour
{

    [SerializeField]
    private Image m_TokenImage;
    private TokenUI m_UIToken;

    private Position m_position;


    public Position Position
    {
        get
        {
            return m_position;
        }

        set
        {
            m_position = value;
        }
    }

    public Image TokenImage
    {
        get
        {
            return m_TokenImage;
        }

        protected set
        {
            m_TokenImage = value;
        }
    }

    public TokenUI UIToken
    {
        get
        {
            return m_UIToken;
        }

        set
        {
            m_UIToken = value;
        }
    }

    public void SetToken(TokenUI token)
    {
        if(token != null)
        {
            if(m_UIToken != null)
            {
                m_UIToken.SetPosition(null);
            }

            m_UIToken = token;
            m_TokenImage.enabled = true;
            m_TokenImage.color = token.Color;
        }
        else
        {
            m_UIToken = null;
            m_TokenImage.enabled = false;
        }
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
