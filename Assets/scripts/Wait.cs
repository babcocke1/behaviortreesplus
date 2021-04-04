using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : Task
{
    float StartTime;
    public bool waitEnabled = true;
    public override bool run()
    {
        Debug.Log("startTimer");
        StartTime = Time.time;
        return true;
    }
    public override bool isDone()
    {
        return (Time.time - StartTime > 1.0f || !waitEnabled);
    }

}