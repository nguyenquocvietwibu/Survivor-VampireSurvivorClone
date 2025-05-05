using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IDieAbility
{
    public event UnityAction DiePerformed;
    public void Die();
}
