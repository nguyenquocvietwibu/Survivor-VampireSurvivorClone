using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Class SO mô tả các chỉ số của 1 đối tượng
/// </summary>
[CreateAssetMenu(fileName = "New Object Stats SO", menuName = "Scriptable Objects/Object Stats")]
public class StatsSO : ScriptableObject
{
    public List<StatEntry> statList = new();

    public Dictionary<Stat, StatEntry> statDict = new();

    public event UnityAction StatUpdatePerformed;

    /// <summary>
    /// Clone lại chỉ số gốc
    /// </summary>
    /// <returns></returns>
    public StatsSO GetCloneSO()
    {
        List<StatEntry> cloneStatList = new();
        Dictionary<Stat, StatEntry> cloneStatDict = new();
        foreach (StatEntry stat in statList)
        {
            StatEntry cloneStat = new()
            {
                statKey = stat.statKey,
                statValue = stat.statValue,
            };
            if (!cloneStatDict.ContainsKey(cloneStat.statKey))
            {
                Debug.Log("Yes");
                cloneStatDict.Add(cloneStat.statKey, cloneStat);
            }
            else
            {
                throw new System.Exception($"Trùng lặp key chỉ số {cloneStat.statKey}");
            }
            cloneStatList.Add(cloneStat);
        }
        StatsSO cloneObjectStatsSO = Instantiate(this);
        cloneObjectStatsSO.statList = cloneStatList;
        cloneObjectStatsSO.statDict = cloneStatDict;
        return cloneObjectStatsSO;
    }

    //public void UpdateStat(Stat statKey)
    //{
    //    foreach (StatEntry stat in statList)
    //    {
    //        if (stat.statKey == statKey && statDict.ContainsKey(statKey))
    //        {
    //            stat.statValue = statDict[statKey].statValue;
    //        }
    //    }
    //}

    /// <summary>
    /// Lấy ra stat nếu có
    /// </summary>
    /// <param name="statKey"></param>
    /// <returns></returns>
    public StatEntry GetStat(Stat statKey)
    {
        if (statDict.ContainsKey(statKey))
        {
            return statDict[statKey];
        }
        else
        {
            throw new System.Exception($"Không có chỉ số{statKey}");
        }
        //foreach (StatObject stat in statList)
        //{
        //    if (stat.statKey == statKey)
        //    {
        //        return stat;
        //    }
        //}
    }

    public float GetStatValue(Stat statKey)
    {
        if (statDict.ContainsKey(statKey))
        {
            return statDict[statKey].statValue;
        }
        else
        {
            throw new System.Exception($"Không có chỉ số{statKey}");
        }
    }

    public void SetStatValue(Stat statKey, float statValue)
    {
        if (statDict.ContainsKey(statKey))
        {
            statDict[statKey].statValue = statValue;
            StatUpdatePerformed?.Invoke();
        }
        else
        {
            throw new System.Exception($"Không có chỉ số{statKey}");
        }
    }

    public void UpdateStat()
    {

    }
    
    public void RemoveStat(Stat statNameKey)
    {
        foreach (StatEntry stat in statList)
        {
            if (stat.statKey == statNameKey)
            {
                statList.Remove(stat);
            }
        }
    }

    public void AddStat(Stat statKey, float statValue)
    {
        bool shouldAddStat = false;
        foreach (StatEntry stat in statList)
        {
            if (stat.statKey == statKey)
            {
                shouldAddStat = false;
                break;
            }
            else
            {
                shouldAddStat = true;
            }
        }
        if (shouldAddStat)
        {
            StatEntry stat = new()
            {
                statKey = statKey,
                statValue = statValue,
            };
            statList.Add(stat);
        }
    }



}
