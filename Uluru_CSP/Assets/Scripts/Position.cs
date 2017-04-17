using UnityEngine;

public class Position : MonoBehaviour
{
    protected static int nextIndex = 0;

    [SerializeField]
    private int m_index;

    public int Index
    {
        get { return m_index; }
        protected set { m_index = value; }
    }

    public Position()
    {
        Index = nextIndex++;
    }

    public void ResetIndices()
    {
        nextIndex = 0;
    }
}
