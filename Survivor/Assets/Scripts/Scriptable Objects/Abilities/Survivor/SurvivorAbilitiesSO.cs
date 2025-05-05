using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SurvivorAbilitiesSO : AbilitiesSO
{
    public Survivor survivor;

    public override void ReceiveAbility(MonoBehaviour receivedMonobehaviorObject)
    {
        if (receivedMonobehaviorObject is Survivor)
        {
            survivor = receivedMonobehaviorObject as Survivor;
        }
    }
}

