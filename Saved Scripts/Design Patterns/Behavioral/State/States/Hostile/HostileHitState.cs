using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HostileHitState : HostileState
{
    public HostileHitState(Hostile hostile) : base(hostile)
    {

    }

    public override void EnterState()
    {
        hostile.animator.speed = 0f;
        hostile.rigidBody2D.velocity = Vector3.zero;
    }

    public override void ExitState()
    {

        hostile.animator.speed = 1f;
    }

    public override void UpdateState()
    {

        if (hostile.basicAbilitiesSO.canMove)
        {
            hostile.stateMachineSO.SwitchState(hostile.statesManager.moveState);
        }
    }
}
