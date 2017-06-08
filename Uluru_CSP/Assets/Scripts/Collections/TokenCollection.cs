using System.Collections.Generic;

/// <summary>
/// Class summary goes here...
/// </summary>
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
