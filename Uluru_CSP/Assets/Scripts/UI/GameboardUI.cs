using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameboardUI : MonoBehaviour
{
    private enum enButtonType { NONE = -1, POSITION, TOKEN };

    [SerializeField]
    private EventSystem m_EventSystem;
    private GameObject m_LastSelectedGameObject = null;
    private enButtonType m_LastSelectedButtonType = enButtonType.NONE;

    void Update()
    {
        
    }

    public void PositionButtonClicked(GameObject clickedButton)
    {
        //Debug.Log(m_EventSystem.currentSelectedGameObject.name);
        Debug.Log(clickedButton.name);

        if(m_LastSelectedGameObject == null || m_LastSelectedButtonType == enButtonType.POSITION)
        {
            m_LastSelectedGameObject = clickedButton;
            m_LastSelectedButtonType = enButtonType.POSITION;
        }
        else if(m_LastSelectedGameObject != null && m_LastSelectedButtonType == enButtonType.TOKEN)
        {
            var positionButton = clickedButton.GetComponent<PositionUI>();
            var tokenButton = m_LastSelectedGameObject.GetComponent<TokenUI>();

            positionButton.SetToken(tokenButton);
            tokenButton.SetPosition(positionButton);

            m_LastSelectedGameObject = null;
            m_LastSelectedButtonType = enButtonType.NONE;
        }
    }

    public void TokenButtonClicked(GameObject clickedButton)
    {
        //Debug.Log(m_EventSystem.currentSelectedGameObject.name);
        Debug.Log(clickedButton.name);

        if (m_LastSelectedGameObject == null || m_LastSelectedButtonType == enButtonType.TOKEN)
        {
            m_LastSelectedGameObject = clickedButton;
            m_LastSelectedButtonType = enButtonType.TOKEN;
        }
        else if (m_LastSelectedGameObject != null && m_LastSelectedButtonType == enButtonType.POSITION)
        {
            var positionButton = m_LastSelectedGameObject.GetComponent<PositionUI>();
            var tokenButton = clickedButton.GetComponent<TokenUI>();

            positionButton.SetToken(tokenButton);
            tokenButton.SetPosition(positionButton);

            m_LastSelectedGameObject = null;
            m_LastSelectedButtonType = enButtonType.NONE;
        }
    }

    
}
