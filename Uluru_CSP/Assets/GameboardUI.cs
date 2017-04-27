using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameboardUI : MonoBehaviour
{
    [SerializeField]
    private EventSystem m_EventSystem;
    private GameObject m_LastSelectedGameObject;

    void Update()
    {
        //m_LastSelectedGameObject
    }

    public void PositionButtonClicked(GameObject positionButton)
    {
        Debug.Log(m_EventSystem.currentSelectedGameObject.name);
    }

    public void TokenButtonClicked(GameObject tokenButton)
    {
        Debug.Log(m_EventSystem.currentSelectedGameObject.name);
    }

    
}
