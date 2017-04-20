using System.Collections;
using UnityEngine;

//Simple Hourglass to stop time
public class Hourglass : MonoBehaviour
{
    [SerializeField]
    private double m_duration;
    [SerializeField]
    private double m_remainingTime;
    [SerializeField]
    private bool m_active;
    private bool m_finished;

    public double   Duration
    {
        get { return m_duration; }
        set { m_duration = value; }
    }
    public double RemainingTime
    {
        get { return m_remainingTime; }
        set { m_remainingTime = value; }
    }
    //Indicates if the hourglass is "running", will be still active even if finished
    public bool Active
    {
        get { return m_active; }
        protected set { m_active = value; }
    }
    //Indicates if the hourglass finished it's "measurement"
    public bool Finished
    {
        get { return m_finished; }
        protected set { m_finished = value; }
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
        Finished = true;
    }
}
