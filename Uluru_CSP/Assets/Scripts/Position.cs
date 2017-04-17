public class Position
{
    protected static int nextIndex = 0;

    public int Index { get; protected set; }

    public Position()
    {
        Index = nextIndex++;
    }

    public void ResetIndices()
    {
        nextIndex = 0;
    }
}
