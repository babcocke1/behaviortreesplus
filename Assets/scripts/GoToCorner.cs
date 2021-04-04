using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToCorner : Task
{
    public GameObject character;
    public GameObject corner;
    public NPCMove ai;
    public bool done = false;
    public override bool run()
    {
        Debug.Log("GTC");
        ai.destination = corner.transform;
        ai.setDestination();
        return true;
    }
    public override bool isDone()
    {
        if (done)
        {
            Debug.Log("GTC UNDONE");
            done = false;
            return true;
        }
        return done;
    }

}
