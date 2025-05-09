using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IModifyStatAbility
{
    public event UnityAction ModifiyStatPerformed;
    public void ModifyStat();
}
