using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Joe Guard Level Up Abilities SO", menuName = "Scriptable Objects/Abilities/General/Level Up/Joe Guard Level Up")]
public class JoeGuardLevelUpAbilitySO : LevelUpAbilitySO
{
    public override void PerformLevelUp(CharacterStatsSO statSO)
    {
        statSO.level += 1;
        statSO.attackPower += 1;
        statSO.defense += 1;
    }
}
