﻿using System.Collections;
using UnityEngine;

//Simple Hourglass to stop time
public class Hourglass : MonoBehaviour
{
    [SerializeField]
    private double m_Duration;
    [SerializeField]
    private double m_RemainingTime;
    [SerializeField]
    private bool m_Active;
    private bool m_Finished;

    public double   Duration
    {
        get { return m_Duration; }
        set { m_Duration = value; }
    }
    public double RemainingTime
    {
        get { return m_RemainingTime; }
        set { m_RemainingTime = value; }
    }
    //Indicates if the hourglass is "running", will be still active even if finished
    public bool Active
    {
        get { return m_Active; }
        protected set { m_Active = value; }
    }
    //Indicates if the hourglass finished it's "measurement"
    public bool Finished
    {
        get { return m_Finished; }
        protected set { m_Finished = value; }
    }

    //Starts the hourglass, does not reset
    public void     Start ()
    {
        Active = true;
        Finished = false;
        StartCoroutine(UpdateTime());
    }

    //Stops the hourglass, does not reset
    public void     Stop()
    {
        Active = false;
        StopCoroutine(UpdateTime());
    }

    //Resets the hourglass, can start or stop it
    //If null is passed the current state will be remained
    public bool     Reset(bool? active = null)
    {
        RemainingTime = Duration;
        Finished = false;

        this.Active = active ?? this.Active;

        if(!Active) { Stop(); }

        return this.Active;
    }

    //Coroutine to handle time measure
    private IEnumerator UpdateTime()
    {
        while(RemainingTime > 0.0 && Active)
        {
            RemainingTime -= Time.deltaTime;
            yield return null;
        }

        RemainingTime = 0.0;
        Finished = true;
    }
}
