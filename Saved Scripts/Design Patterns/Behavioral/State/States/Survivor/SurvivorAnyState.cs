using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorAnyState : SurvivorState
{
    public SurvivorAnyState(Survivor survivor) : base(survivor)
    {
    }

    public override void EnterState()
    {
        //throw new System.NotImplementedException();
    }

    public override void ExitState()
    {
        //throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        if (survivor.survivorAbilitiesManager.survivorBaseAbilites.IsDamaged)
        {
            survivor.stateMachineSO.SwitchState(survivor.survivorStatesManager.idleState);
        }
    }
}
