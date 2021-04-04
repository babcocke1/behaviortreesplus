using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class OpenDoor : Task
{
    public pathFollow p;
    public override bool run()
    {
        p.openDoor();
        return true;
    }
    public override bool isDone()
    {
        return true;
    }
}

