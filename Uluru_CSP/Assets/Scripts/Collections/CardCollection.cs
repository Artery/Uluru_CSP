using System.Collections.Generic;

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
}
