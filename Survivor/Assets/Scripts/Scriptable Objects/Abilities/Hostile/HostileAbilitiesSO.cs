using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HostileAbilitesSO : AbilitiesSO
{
    public Hostile hostile;

    public override void ReceiveAbility(MonoBehaviour receivedMonobehaviorObject)
    {
        if (receivedMonobehaviorObject is Hostile)
        {
            hostile = receivedMonobehaviorObject as Hostile;
        }
    }
}
