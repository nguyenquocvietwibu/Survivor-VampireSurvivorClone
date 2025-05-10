using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HostileState : StateBehavior
{
    public Hostile hostile;

    public HostileState(Hostile hostile)
    {
        this.hostile = hostile;
    }

}
