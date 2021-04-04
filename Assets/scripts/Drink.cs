using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : Task
{
    public GameObject character;
    public GameObject drink;
    public NPCMove ai;
    bool drinkEnabled = true;
    public override bool run()
    {
        Debug.Log("drink");
        if (drinkEnabled)
        {
            if (character.transform.position.x > 0)
            {
                drink.transform.position = new Vector3(12f, .73333333333f, -12f);
            }
            else
            {
                drink.transform.position = new Vector3(-12f, .73333333333f, 12f);
            }
            ai.destination = drink.transform;
            ai.setDestination();
        }
        return drinkEnabled;
    }
    public override bool isDone()
    {
        if ((character.transform.position - drink.transform.position).magnitude < .05)
        {
            drink.transform.position = new Vector3(-100f, -100f, -100f);
            return true;
        }
        else if (!drinkEnabled)
        {
            return true;
        }
        return false;
    }
    public void disableDrink()
    { 
        drinkEnabled = false;
        drink.transform.position = new Vector3(-100f, -100f, -100f);
    }
    public void enableDrink()
    {
        Debug.Log("drink enable");
        drinkEnabled = true;
    }
}