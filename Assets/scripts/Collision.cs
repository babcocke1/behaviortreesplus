using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public NPCMove nma;
    public GameObject g;
    public GoToCorner gtc;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision ");
        Debug.Log("GTC done ");
        gtc.done = true;
    
        if( (g.transform.position - new Vector3(13.2f, .89f, 13f)).magnitude < 1)
        {
            g.transform.position = new Vector3(-13f, .89f, -13f);
            //nma.setDestination();
        }
        else if ((g.transform.position - new Vector3(-13f, .89f, -13f)).magnitude < 1)
        {
            g.transform.position = new Vector3(13.2f, .89f, 13f);
            //nma.setDestination();

        }

    }
}
