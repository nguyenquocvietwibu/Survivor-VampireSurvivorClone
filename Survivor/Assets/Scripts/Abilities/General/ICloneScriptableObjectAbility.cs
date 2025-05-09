using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICloneScriptableObjectAbility<T> where T : ScriptableObject
{
    public T GetCloneSO();
}
