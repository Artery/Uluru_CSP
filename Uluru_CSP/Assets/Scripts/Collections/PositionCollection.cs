using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class summary goes here...
/// </summary>
public class PositionCollection : List<Position>
{
    public PositionCollection()
        : base()
    {
    }

    public PositionCollection(IEnumerable<Position> collection)
        :base()
    {
        AddRange(collection);
    }
}
