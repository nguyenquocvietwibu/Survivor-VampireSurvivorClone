﻿using System.Collections;
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
       

        // Kiểm tra nếu animation có tên là "Animation" và đã chạy xong
        
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        if (survivor.playerInputVector2 == Vector2.zero)
        {
            survivor.stateMachineSO.SwitchState(survivor.survivorStatesManager.idleState);
        }
        else
        {
        }
    }
}
