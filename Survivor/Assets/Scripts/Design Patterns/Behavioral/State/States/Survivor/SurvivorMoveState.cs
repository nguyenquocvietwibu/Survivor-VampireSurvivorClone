using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SurvivorMoveState : SurvivorState
{
    public SurvivorMoveState(Survivor survivor) : base(survivor)
    {
        stateName = this.GetType().Name;
        stateDescriptions = new string[]
        {
            "Di chuyển theo input vector 2 của player",
            "Chuyển về idle state nếu không có input vector 2 từ player",
        };
    }

    public override void EnterState()
    {
        survivor.animator.Play(SurvivorAnimationHash.moveHash);
        survivor.basicAbilitiesSO.Move(survivor.playerInputVector2);
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        if (survivor.playerInputVector2 == Vector2.zero)
        {
            survivor.stateMachineSO.SwitchState(survivor.statesManager.idleState);
        }
        else
        {
            survivor.basicAbilitiesSO.Move(survivor.playerInputVector2);
        }
    }
}
