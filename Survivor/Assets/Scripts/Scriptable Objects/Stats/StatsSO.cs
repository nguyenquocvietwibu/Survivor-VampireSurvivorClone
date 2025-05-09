using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Class SO mô tả các chỉ số của 1 đối tượng
/// </summary>
[CreateAssetMenu(fileName = "New Object Stats SO", menuName = "Scriptable Objects/Object Stats")]
public class StatsSO : ScriptableObject, IModifyStatAbility, ICloneScriptableObjectAbility<StatsSO>
{
    public List<StatEntry> statList = new();

    public Dictionary<Stat, StatEntry> statDict = new();

    public event UnityAction ModifiyStatPerformed;

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
                cloneStatDict.Add(cloneStat.statKey, cloneStat);
            }
            else
            {
                throw new System.Exception($"Trùng lặp key chỉ số {cloneStat.statKey}");
            }
            cloneStatList.Add(cloneStat);
        }
        StatsSO cloneObjectStatsSO = ScriptableObject.CreateInstance<StatsSO>();
        cloneObjectStatsSO.statList = cloneStatList;
        cloneObjectStatsSO.statDict = cloneStatDict;
        return cloneObjectStatsSO;
    }

    /// <summary>
    /// Function kiểm tra xem chỉ số được truyền có thể tăng không
    /// </summary>
    /// <param name="statKey"></param>
    /// <returns></returns>
    public bool CanIncreaseStat(Stat statKey)
    {
        return statDict[statKey].canIncrease;
    }

    /// <summary>
    /// Function kiểm tra xem chỉ số được truyền có thể giảm không
    /// </summary>
    /// <param name="statKey"></param>
    /// <returns></returns>
    public bool CanDecreaseStat(Stat statKey)
    {
        return statDict[statKey].canDecrease;
    }

    /// <summary>
    /// Phương thức kiểm tra xem có tồn tại chỉ số được truyền trong các chỉ số đang có không
    /// </summary>
    /// <param name="statKey"></param>
    /// <returns></returns>
    public bool ContainStatKey(Stat statKey)
    {
        if (statDict.ContainsKey(statKey))
        {
            return true;
        }
        else
        {
            return false;
        }
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
    //protected StatEntry GetStat(Stat statKey)
    //{
    //    if (statDict.ContainsKey(statKey))
    //    {
    //        return statDict[statKey];
    //    }
    //    else
    //    {
    //        throw new System.Exception($"Không có chỉ số{statKey}");
    //    }
    //    //foreach (StatObject stat in statList)
    //    //{
    //    //    if (stat.statKey == statKey)
    //    //    {
    //    //        return stat;
    //    //    }
    //    //}
    //}

    /// <summary>
    /// Function lấy ra giá trị của chỉ số truyền vào nếu không có thì trả về 0f kèm debuglog
    /// </summary>
    /// <param name="statKey"></param>
    /// <returns></returns>
    public float GetStatValue(Stat statKey)
    {
        if (statDict.ContainsKey(statKey))
        {
            return statDict[statKey].statValue;
        }
        else
        {
            Debug.Log($"Không có chỉ số{statKey}");
            return 0f;
        }
    }

    /// <summary>
    /// Function cài giá trị của stat
    /// </summary>
    /// <param name="statKey"></param>
    /// <param name="statValue"></param>
    public void SetStatValue(Stat statKey, float statValue)
    {
        if (statDict.ContainsKey(statKey))
        {
            if (statDict[statKey].statValue != statValue)
            {
                statDict[statKey].statValue = statValue;
                ModifyStat();
            }
        }
        else
        {
            throw new System.Exception($"không có chỉ số{statKey} để set");
        }
    }

    public void ModifyStat()
    {
        ModifiyStatPerformed?.Invoke();
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
