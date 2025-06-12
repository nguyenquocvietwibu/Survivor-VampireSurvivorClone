using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IDieAble
{
    public event UnityAction DiePerformed;
    public bool IsDead {  get; set; }
    public void Die();
}
