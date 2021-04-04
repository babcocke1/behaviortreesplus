using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : Task
{
    public GameObject character;
    public GameObject food;
    public NPCMove ai;
    bool foodEnabled = true;
    public override bool run()
    {
        Debug.Log("eat");
        if (foodEnabled)
        {
            if (character.transform.position.x > 0)
            {
                food.transform.position = new Vector3(6f, .73333333333f, -12f);
            }
            else
            {
                food.transform.position = new Vector3(-6f, .73333333333f, 12f);
            }
            ai.destination = food.transform;
            ai.setDestination();
        }
        return foodEnabled;
    }
    public override bool isDone()
    {
        if ((character.transform.position - food.transform.position).magnitude < .05)
        {
            food.transform.position = new Vector3(-100f, -100f, -100f);
            return true;
        }
        else if(!foodEnabled)
        { 
            return true;
        }
        return false;
    }
    public void disableFood()
    {

        foodEnabled = false;
        food.transform.position = new Vector3(-100f, -100f, -100f);
    }
    public void enableFood()
    {
        Debug.Log("food enable");
        foodEnabled = true;
    }
}


