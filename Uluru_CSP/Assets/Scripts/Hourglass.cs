using System.Collections;
using UnityEngine;

//Simple Hourglass to stop time
public class Hourglass : MonoBehaviour
{
    public double   duration        { get; set; }
    public double   remainingTime   { get; protected set; }
    //Indicates if the hourglass is "running", will be still active even if finished
    public bool     active          { get; protected set; }
    //Indicates if the hourglass finished it's "measurement"
    public bool     finished        { get; protected set; }

    //Starts the hourglass, does not reset
    public void     Start ()
    {
        active = true;
        finished = false;
        StartCoroutine(UpdateTime());
    }

    //Stops the hourglass, does not reset
    public void     Stop()
    {
        active = false;
        StopCoroutine(UpdateTime());
    }

    //Resets the hourglass, can start or stop it
    //If null is passed the current state will be remained
    public bool     Reset(bool? active = null)
    {
        remainingTime = duration;
        finished = false;

        this.active = active ?? this.active;

        return this.active;
    }

    //Coroutine to handle time measure
    private IEnumerator UpdateTime()
    {
        while(remainingTime > 0.0)
        {
            remainingTime -= Time.deltaTime;
            yield return null;
        }
        finished = true;
    }
}
