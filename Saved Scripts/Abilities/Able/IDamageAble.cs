using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IDamageAble
{
    public event UnityAction DamagePerformed;

    public bool CanDamage { get; set; }
    public bool IsDamaged { get; set; }
    public void Damage(float damageAmount);
}
