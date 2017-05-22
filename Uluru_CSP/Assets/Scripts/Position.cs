using UnityEngine;
using UnityEngine.UI;

//This class represents one Position on e.g. the Gameboard
public class Position : UIButtonBase
{
    protected static int nextIndex = 0;

    [SerializeField]
    private int m_Index;
    [SerializeField]
    private Edge m_Edge;
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
        get { return m_Index; }
        protected set { m_Index = value; }
    }

    public Edge Edge
    {
        get { return m_Edge; }
        set { m_Edge = value; }
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
        if (tokenColor != null)
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
