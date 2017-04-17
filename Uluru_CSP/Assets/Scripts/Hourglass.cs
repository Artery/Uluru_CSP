using System.Collections;
using UnityEngine;

//Simple Hourglass to stop time
public class Hourglass : MonoBehaviour
{
    public double   Duration        { get; set; }
    public double   RemainingTime   { get; protected set; }
    //Indicates if the hourglass is "running", will be still active even if finished
    public bool     Active          { get; protected set; }
    //Indicates if the hourglass finished it's "measurement"
    public bool     Finished        { get; protected set; }

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
        while(RemainingTime > 0.0)
        {
            RemainingTime -= Time.deltaTime;
            yield return null;
        }
        Finished = true;
    }
}
