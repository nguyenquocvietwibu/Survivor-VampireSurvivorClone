using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IReviveAbility
{
    public event UnityAction RevivePerformed;
    public void Revive();
}
