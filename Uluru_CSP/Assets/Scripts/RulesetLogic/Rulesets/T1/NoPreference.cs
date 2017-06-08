using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class summary goes here...
/// </summary>
public class NoPreference : IRuleset
{
    #region Fields
    #endregion

    #region Properties
    #endregion

    #region Constructors
    public NoPreference() { }
    #endregion

    #region Methods
    #region InterfaceMethods
    public void Initialize(PositionTokenTuple origin, PositionTokenTuple dependecy) { }

    public bool Evaluate()
    {
        return true;
    }
    #endregion
    #region ClassMethods
    #endregion
    #endregion
}
