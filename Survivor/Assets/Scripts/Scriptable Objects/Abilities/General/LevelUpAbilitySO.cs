using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class LevelUpAbilitySO : AbilitySO
{
    public abstract void PerformLevelUp(CharacterStatsSO statSO);
}
