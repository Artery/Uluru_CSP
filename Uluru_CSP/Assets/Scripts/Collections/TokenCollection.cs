using System.Collections.Generic;

public class TokenCollection : List<Token>
{
    public TokenCollection()
        : base()
    {
    }

    public TokenCollection(IEnumerable<Token> collection)
        :base()
    {
        AddRange(collection);
    }
}
