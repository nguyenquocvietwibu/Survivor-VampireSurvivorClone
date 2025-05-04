using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SurvivorAbilitiesSO : AbilitiesSO
{
    public Survivor survivor;
    public void ReceiveAbility(Survivor receivedSurvivor)
    {
        survivor = receivedSurvivor;
    }
}

