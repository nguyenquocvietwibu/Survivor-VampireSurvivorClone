using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorDisappearState : SurvivorState
{
    public SurvivorDisappearState(Survivor survivor) : base(survivor)
    {
        stateName = this.GetType().Name;
        stateDescriptions = new string[]
        {
            "Biến mất",
            "Lúc đang biến mất thì không được di chuyển",
        };
    }

    public override void EnterState()
    {
        survivor.animator.Play(SurvivorAnimationHash.disappearHash);
        //survivor.survivorBasicAbilitiesSO.canMove = false;
    }

    public override void ExitState()
    {
        //survivor.survivorBasicAbilitiesSO.canMove = true;
    }

    public override void UpdateState()
    {
        AnimatorStateInfo stateInfo = survivor.animator.GetCurrentAnimatorStateInfo(0);
        Debug.Log($"state info: {stateInfo.normalizedTime}");
        
    }
}
