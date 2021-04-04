using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathFollow : MonoBehaviour
{
    float start;
    public Rigidbody g;
    public float v;
    public bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
       // g.AddForce(new Vector3(0f, 0f, -v), ForceMode.VelocityChange);
    }

    // Update is called once per frame
   // void Update()
    //{
        //Debug.Log(g.velocity);
        //Debug.Log(Mathf.Abs(g.transform.position.z) - 12f  );
        //if (12f - Mathf.Abs(g.transform.position.z)  < .5f && Time.time - start > .5f )
        //{
            //start = Time.time;
            //g.AddForce(new Vector3(0f, 0f, -2f  *g.velocity.z), ForceMode.VelocityChange);
       // }
         //else
       // {
            //g.AddForce(new Vector3(0f, 0f, (g.velocity.z / Mathf.Abs(g.velocity.z)) * v - g.velocity.z), ForceMode.VelocityChange);
       // }
    //}
    public void openDoor() {
        //if door closed
        if (!isOpen)
        {
            g.position = new Vector3(100f, -15f, 0);
            isOpen = true;
        }     
    }
    public void closeDoor()
    {
        if (isOpen)
        {
            g.position = new Vector3(0, 0.5f, 0); 
            isOpen = false;
        }
    }
}
