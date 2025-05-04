using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Carl Anger Level Up Abilities SO", menuName = "Scriptable Objects/Abilities/General/Level Up/Carl Anger Level Up")]
public class CarlAngerLevelUpAbilitySO : LevelUpAbilitySO
{
    public override void PerformLevelUp(CharacterStatsSO statSO)
    {
        statSO.level += 1;
        statSO.attackPower += 3;
    }
}
