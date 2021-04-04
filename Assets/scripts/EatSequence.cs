using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatSequence : MonoBehaviour
{
    public class CloseDoorSequence : Task
    {
        public Task[] children = new Task[1];
        int next = 0;

        public override bool run()
        {
            children[next].run();
            return true;
        }
        public bool nextReady()
        {
            if (children[next].isDone())
            {
                next++;
                return true;
            }
            return false;
        }
        public override bool isDone()
        {

            if (next >= children.Length)
            {
                next = 0;
                return true;
            }
            else return false;
        }
    }


}
