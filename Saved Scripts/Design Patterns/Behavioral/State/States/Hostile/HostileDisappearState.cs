using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileDisappearState : HostileState
{
    public HostileDisappearState(Hostile hostile) : base(hostile)
    {
    }
    public override void EnterState()
    {
        hostile.animator.Play(HostileAnimationHash.DisappearHash);
        hostile.basicAbilitiesSO.DropItem();
        hostile.basicAbilitiesSO.canMove = false;
        hostile.basicAbilitiesSO.canDamage = false;

    }

    public override void ExitState()
    {
        hostile.basicAbilitiesSO.canMove = true;
        hostile.basicAbilitiesSO.canDamage = true;
    }

    public override void UpdateState()
    {
        AnimatorStateInfo stateInfo = hostile.animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.shortNameHash == HostileAnimationHash.DisappearHash && stateInfo.normalizedTime >= 1f)
        {
            hostile.basicAbilitiesSO.Die();
            //Debug.Log("Hostile Die");
        }
    }
}
