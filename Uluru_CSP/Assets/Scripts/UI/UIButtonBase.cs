using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonBase : MonoBehaviour
{
    [SerializeField]
    protected bool m_IsUnlocked;
    [SerializeField]
    protected Button m_Button;

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
}
