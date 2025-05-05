using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Carl Anger Level Up Abilities SO", menuName = "Scriptable Objects/Abilities/General/Level Up/Carl Anger Level Up")]
public class CarlAngerLevelUpAbilitySO : LevelUpAbilitySO
{
    public override void PerformLevelUp(StatsSO statSO)
    {
        statSO.GetStat(Stat.Level).statValue += 1;
        statSO.GetStat(Stat.AttackPower).statValue += 3;
    }
}
