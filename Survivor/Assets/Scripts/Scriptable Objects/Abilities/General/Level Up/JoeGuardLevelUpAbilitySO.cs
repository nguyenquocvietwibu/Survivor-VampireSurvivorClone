using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Joe Guard Level Up Abilities SO", menuName = "Scriptable Objects/Abilities/General/Level Up/Joe Guard Level Up")]
public class JoeGuardLevelUpAbilitySO : LevelUpAbilitySO
{
    public override void PerformLevelUp(StatsSO statSO)
    {
        statSO.GetStat(Stat.Level).statValue += 1;
        statSO.GetStat(Stat.AttackPower).statValue += 1;
        statSO.GetStat(Stat.Health).statValue += 1;
    }
}
