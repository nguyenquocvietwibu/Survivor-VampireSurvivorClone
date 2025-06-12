using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class StateBehavior : IStateBehavior
{
    public string stateName;
    public string[] stateDescriptions;
    public abstract void EnterState();

    public abstract void ExitState();

    public abstract void UpdateState();

}
