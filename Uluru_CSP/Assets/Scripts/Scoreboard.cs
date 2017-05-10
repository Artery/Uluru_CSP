using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    [SerializeField]
    private Text m_NameField;
    [SerializeField]
    private Text m_DrawbackField;
    [SerializeField]
    private Text m_RoundField;
    [SerializeField]
    private Text m_RemainingTimeField;

    public Text NameField
    {
        get { return m_NameField; }
    }

    public Text DrawbackField
    {
        get { return m_DrawbackField; }
    }

    public Text RoundField
    {
        get { return m_RoundField; }
    }

    public Text RemainingTimeField
    {
        get { return m_RemainingTimeField; }
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
