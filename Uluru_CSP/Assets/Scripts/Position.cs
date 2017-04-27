using UnityEngine;

public class Position : MonoBehaviour
{
    
    protected static int nextIndex = 0;

    [SerializeField]
    private int m_index;
    [SerializeField]
    private Edge m_edge;

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
