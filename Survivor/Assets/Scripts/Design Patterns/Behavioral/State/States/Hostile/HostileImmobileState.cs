using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileImmobileState : HostileState
{
    public HostileImmobileState(Hostile hostile) : base(hostile)
    {

    }

    public override void EnterState()
    {
        hostile.animator.speed = 0f;
    }

    public override void ExitState()
    {
        hostile.animator.speed = 1f;
    }

    public override void UpdateState()
    {
       
    }
}
