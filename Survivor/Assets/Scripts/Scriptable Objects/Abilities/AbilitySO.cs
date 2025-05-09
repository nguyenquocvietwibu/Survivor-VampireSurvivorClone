using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilitySO : ScriptableObject, ICloneScriptableObjectAbility<AbilitySO>
{
    public string abilityName;
    public string[] abilityDescription;

    public abstract AbilitySO GetCloneSO();
}
