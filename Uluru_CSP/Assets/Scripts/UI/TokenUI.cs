using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenUI : MonoBehaviour
{
    private PositionUI m_UIPosition;

    private UnityEngine.Color m_TokenColor;

    public UnityEngine.Color Color
    {
        get
        {
            return m_TokenColor;
        }

        protected set
        {
            m_TokenColor = value;
        }
    }

    public PositionUI UIPosition
    {
        get
        {
            return m_UIPosition;
        }

        set
        {
            m_UIPosition = value;
        }
    }

    public void SetPosition(PositionUI position)
    {
        if (position != null)
        {
            if (m_UIPosition != null)
            {
                m_UIPosition.SetToken(null);
            }

            m_UIPosition = position;
        }
        else
        {
            m_UIPosition = null;
        }
    }

    // Use this for initialization
    void Start ()
    {
        m_TokenColor = this.GetComponent<Button>().colors.normalColor;

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}


}
