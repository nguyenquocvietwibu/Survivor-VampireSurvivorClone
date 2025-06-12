using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SurvivorIdleState : SurvivorState
{
    public SurvivorIdleState(Survivor survivor) : base(survivor)
    {
        stateName = this.GetType().Name;
        stateDescriptions = new string[]
        {
            "Đứng yên nhàn rỗi",
            "Nếu có input từ player thì sẽ chuyển sang Move State",
        };
    }

    public override void EnterState()
    {
        //Debug.Log(survivor.animator);
        survivor.animator.Play(SurvivorAnimationHash.idleHash);
        
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        //AnimatorStateInfo stateInfo = survivor.animator.GetCurrentAnimatorStateInfo(0);
        //Debug.Log($"state info: {stateInfo.normalizedTime}");
        if (survivor.playerInputVector2 != Vector2.zero)
        {
            survivor.stateMachineSO.SwitchState(survivor.survivorStatesManager.moveState);
        }
    }
}
