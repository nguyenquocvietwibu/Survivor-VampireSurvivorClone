using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IDisappearAbility
{
    public event UnityAction DisappearPerformed;
    public void Disappear();
}
