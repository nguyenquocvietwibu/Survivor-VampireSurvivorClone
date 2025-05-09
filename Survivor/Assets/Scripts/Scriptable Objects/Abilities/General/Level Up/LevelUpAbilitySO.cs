using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "New Default Level Up Abilities SO", menuName = "Scriptable Objects/Abilities/General/Level Up")]

public class LevelUpAbilitySO : AbilitySO
{
    public List<BonusStatEntry> bonusStatList;

    public Dictionary<Stat, BonusStatEntry> bonusStatDict = new();

    public override AbilitySO GetCloneSO()
    {
        List<BonusStatEntry> cloneStatList = new();
        Dictionary<Stat, BonusStatEntry> cloneBonusStatDict = new();
        foreach (BonusStatEntry bonusStat in bonusStatList)
        {
            BonusStatEntry bonusStatEntry = new()
            {
                bonusStatKey = bonusStat.bonusStatKey,
                bonusStatValue = bonusStat.bonusStatValue,
            };
            if (!cloneBonusStatDict.ContainsKey(bonusStatEntry.bonusStatKey))
            {
                cloneBonusStatDict.Add(bonusStatEntry.bonusStatKey, bonusStatEntry);
            }
            else
            {
                throw new System.Exception($"Trùng lặp key chỉ số bonus {bonusStatEntry.bonusStatKey}");
            }
            cloneStatList.Add(bonusStatEntry);
        }
        LevelUpAbilitySO cloneLevelUpAbilitySO = ScriptableObject.CreateInstance<LevelUpAbilitySO>();
        cloneLevelUpAbilitySO.bonusStatList = cloneStatList;
        return cloneLevelUpAbilitySO;
    }


    public void PerformLevelUp(StatsSO statSO)
    {
        foreach (BonusStatEntry bonusStat in bonusStatList)
        {
            if (statSO.ContainStatKey(bonusStat.bonusStatKey) && statSO.CanIncreaseStat(bonusStat.bonusStatKey))
            {
                statSO.SetStatValue(bonusStat.bonusStatKey, statSO.GetStatValue(bonusStat.bonusStatKey) + bonusStat.bonusStatValue);
            }
        }
    }
}
