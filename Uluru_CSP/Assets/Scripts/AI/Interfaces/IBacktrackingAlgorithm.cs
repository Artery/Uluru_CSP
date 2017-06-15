using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Class summary goes here...
/// </summary>
public interface IBacktrackingAlgorithm
{
    #region Fields
    #endregion

    #region Properties

    string Version { get; set; }
    int Loop { get; set; }
    int LoopCounter { get; set; }
    double ExecutionTime { get; set; }

    #endregion

    #region Constructors
    #endregion

    #region Methods
    #region ClassMethods

    List<PositionTokenTuple> ExecuteAlgorithm(List<PositionTokenTuple> assignment, List<Slot> csp, List<Token> tokens);

    #endregion

    #endregion
}
