using UnityEngine;
using UnityEngine.UI;

public class Position : MonoBehaviour
{
    protected static int nextIndex = 0;

    [SerializeField]
    private int m_index;
    [SerializeField]
    private Edge m_edge;

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
    private Image m_TokenImage;

    public Image TokenImage
    {
        get
        {
            return m_TokenImage;
        }

        set
        {
            m_TokenImage = value;
        }
    }

    public void UpdateTokenImageColor(UnityEngine.Color? tokenColor)
    {
        if(tokenColor != null && tokenColor.HasValue)
        {
            TokenImage.enabled = true;
            TokenImage.color = tokenColor.Value;
        }
        else
        {
            TokenImage.enabled = false;
        }

    }

    public int Index
    {
        get { return m_index; }
        protected set { m_index = value; }
    }

    public Edge Edge
    {
        get { return m_edge; }
        set { m_edge = value; }
    }

    

    public Position()
    {
        Index = nextIndex++;
    }

    public Position(int index, Edge edge)
    {
        Index = index;
        Edge = edge;
    }

    public void ResetIndices()
    {
        nextIndex = 0;
    }
}
