using UnityEngine;
using UnityEngine.UI;

public class Position : UIButtonBase
{
    protected static int nextIndex = 0;

    [SerializeField]
    private int m_index;
    [SerializeField]
    private Edge m_edge;
    [SerializeField]
    private Image m_TokenImage;

    public Position()
    {
        Index = nextIndex++;
    }

    public Position(int index, Edge edge)
    {
        Index = index;
        Edge = edge;
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

    public Image TokenImage
    {
        get { return m_TokenImage; }
        set { m_TokenImage = value; }
    }


    public void ResetIndices()
    {
        nextIndex = 0;
    }

    public void UpdateTokenImageColor(UnityEngine.Color? tokenColor)
    {
        if (tokenColor != null && tokenColor.HasValue)
        {
            TokenImage.enabled = true;
            TokenImage.color = tokenColor.Value;
        }
        else
        {
            TokenImage.enabled = false;
        }

    }
}
