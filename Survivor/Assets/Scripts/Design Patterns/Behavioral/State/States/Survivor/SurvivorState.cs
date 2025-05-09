using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class SurvivorState : StateBehavior
{
    public Survivor survivor;

    public SurvivorState(Survivor survivor)
    {
        this.survivor = survivor;
    }
}
