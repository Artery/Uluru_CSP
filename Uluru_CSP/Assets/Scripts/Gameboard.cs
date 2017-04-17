using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameboard
{
    private PositionCollection m_positions = new PositionCollection();

    public PositionCollection Positions
    {
        get
        {
            return m_positions;
        }
    }
}
