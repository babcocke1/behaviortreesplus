using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToDoor : Task
{
    public GameObject character;
    public Transform dest1;
    public Transform dest2;
    public NPCMove ai;
    public override bool run()
    {
        Debug.Log("GTD");
        if (character.transform.position.x > 0f)
            ai.destination = dest1;
        else
            ai.destination = dest2;

        ai.setDestination();
        return true;
    }
    public override bool isDone()
    {
        return ((character.transform.position - ai.destination.position).magnitude < .05);
    }

}
