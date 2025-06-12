using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Lớp trừu tượng mô tả các khả năng các lớp con sẽ c
/// </summary>
public abstract class AbilitiesSO : ScriptableObject, ICloneScriptableObjectAbility<AbilitiesSO>
{
    public string abilitiesName;
    public string[] abilitiesDescription;

    public abstract AbilitiesSO GetCloneSO();

    public abstract void ReceiveAbiliies(MonoBehaviour receivedMonobehaviorObject);
}
