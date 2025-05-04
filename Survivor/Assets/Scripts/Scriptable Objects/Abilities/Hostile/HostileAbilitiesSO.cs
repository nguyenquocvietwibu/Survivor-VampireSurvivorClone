using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HostileAbilitesSO : AbilitiesSO
{
    public Hostile hostile;

    public void ReceiveAbilities(Hostile receivedHostile)
    {
        hostile = receivedHostile;
    }
}
