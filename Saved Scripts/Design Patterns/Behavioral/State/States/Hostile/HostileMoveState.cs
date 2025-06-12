using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class HostileMoveState : HostileState
{
    public HostileMoveState(Hostile hostile) : base(hostile)
    {
    }

    public override void EnterState()
    {
        hostile.animator.Play(HostileAnimationHash.MoveHash);
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        
        if (hostile.basicAbilitiesSO.canMove)
        {
            Vector2 directionVector2 = (hostile.trackedSurvivor.transform.position - hostile.transform.position).normalized;
            hostile.basicAbilitiesSO.Move(Vector2.Lerp(hostile.rigidBody2D.velocity, directionVector2 * hostile.statsManager.currentStatSO.GetStatValue(Stat.MoveSpeed), 1));
        }
    }
}
