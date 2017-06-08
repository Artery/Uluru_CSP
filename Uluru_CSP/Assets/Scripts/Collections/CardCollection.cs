using System.Collections.Generic;

/// <summary>
/// Class summary goes here...
/// </summary>
public class CardCollection : List<RuleCard>
{
    public CardCollection()
        : base()
    {
    }

    public CardCollection(IEnumerable<RuleCard> collection)
        :base()
    {
        AddRange(collection);
    }

    public CardCollection(List<RuleCard> collection)
        : base()
    {
        AddRange(collection);
    }
}
