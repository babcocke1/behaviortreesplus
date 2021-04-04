using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class NPCMove : MonoBehaviour
{
    [SerializeField]
    public Transform destination;
    public Transform door1;
    public Transform door2;
    public GameObject food;
    public GameObject water;
    public GameObject character;
    public pathFollow pf ;
    public Rigidbody door;
    public Button closeDoor;
    GoToCorner gtc = new GoToCorner();
    OpenDoor od = new OpenDoor();
    public GameObject corner;
    GoToDoor gtd = new GoToDoor();
    Eat eat = new Eat();
    Drink drink = new Drink();
    Wait wait = new Wait();
    NavMeshAgent nma;
    int state; //0 means starting //1 means running
    public Collision col;
    public OpenDoorSequence ods = new OpenDoorSequence();
    public CloseDoorSequence cds = new CloseDoorSequence();
    int initialDoor;
    bool foodEnabled = false;
    bool waterEnabled = false;
    bool waitEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        nma = this.GetComponent<NavMeshAgent>();
        eat.character = character;
        eat.food = food;
        eat.ai = this;

        drink.character = character;
        drink.drink = water;
        drink.ai = this;
        
        gtd.dest1 = door1;
        gtd.dest2 = door2;
        gtd.character = character;
        gtd.ai = this;
        gtc.corner = corner;
        gtc.character = character;
        gtc.ai = this;
        //gtc.run();
        od.p = pf;
        ods.children[0] = eat;
        ods.children[1] = drink;
        ods.children[2] = gtd;
        ods.children[3] = wait;
        ods.children[4] = gtc;

        cds.children[0] = eat;
        cds.children[1] = drink;
        cds.children[2] = gtd;
        cds.children[3] = od;
        cds.children[4] = wait;
        cds.children[5] = gtc;

        col.gtc = gtc;
        pf.g = door;
        initialDoor = (pf.isOpen) ? 1 : 0;
        Debug.Log(initialDoor);
       // if (nma == null)
          //  Debug.LogError("the nav mesh agent component is not attached to " + gameObject.name);
        //else
            //setDestination();
    }


    void Update()
    {
        if(initialDoor == 1)
        {
            if (state == 0)
            {
                ods.run();
                state = 1;
            }
            else if(state ==1)
            {
                if (ods.nextReady())
                {
                    if (ods.isDone())
                    {
                        Debug.Log("ODS DONE");
                        state = 0;
                        initialDoor = (pf.isOpen) ? 1 : 0;
                    }
                    else
                        ods.run();
                }
            }
        }
        else
        {
            if (state == 0)
            {
                cds.run();
                state = 1;
            }
            else if (state == 1)
            {
                if (cds.nextReady())
                {
                    if (cds.isDone())
                    {
                        Debug.Log("CDS DONE");
                        state = 0;
                        initialDoor = (pf.isOpen) ? 1 : 0;
                    }
                    else
                        cds.run();
                }
            }
        }
    }

    

            
    
    // Update is called once per frame
    public void setDestination()
    {
        if(destination != null)
        {

            Vector3 targetVector = destination.transform.position;
            nma.SetDestination(targetVector);
            Debug.Log("destination.position = " + destination.transform.position);
        }

    }
    public void closeDoor2()
    {
        if (Mathf.Abs(character.transform.position.x) > 2.1)
        { 
            if(character.transform.position.x < 0 == corner.transform.position.x < 0)
            {
                pf.closeDoor();
            }
        }

    }

    public void handleWaitToggle2()
    {
        waitEnabled = !waitEnabled;
        wait.waitEnabled = waitEnabled;
    }
    
    public void handleFoodToggle()
    {
        foodEnabled = !foodEnabled;
        if (foodEnabled)
        {
            eat.disableFood();
        }
        else
        {
            eat.enableFood();
        }

    }
    public void handleWaterToggle()
    {
        Debug.Log("drinkHandler");
        waterEnabled = !waterEnabled;
        if (waterEnabled)
        {
            drink.disableDrink();
        }
        else
        {
            drink.enableDrink();
        }

    }

}
