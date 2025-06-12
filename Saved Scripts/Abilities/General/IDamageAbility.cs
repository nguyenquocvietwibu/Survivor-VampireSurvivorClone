using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IDamageAbility
{
    public event UnityAction DamagePerformed;
    public void Damage(float damageAmount);
}
