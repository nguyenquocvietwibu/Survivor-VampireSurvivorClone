using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IIdleAbility
{
    public event UnityAction IdlePerformed;
    public void Idle();
}
