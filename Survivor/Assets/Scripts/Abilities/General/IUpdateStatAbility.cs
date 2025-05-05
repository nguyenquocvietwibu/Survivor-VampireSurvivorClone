using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IUpdateStatAbility
{
    public event UnityAction UpdateStatPerformed;
    public void UpdateStat();
}
