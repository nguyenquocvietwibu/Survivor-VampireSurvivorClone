using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class quản lí stats gồm stats hiện tại và stats tối đa
/// </summary>
public class StatsManager : MonoBehaviour
{
    public StatsSO currentStatSO;
    public StatsSO maxStatSO;


    /// <summary>
    /// Phương thức thực hiện clone lại StatSO đưa vào currentStatSo sau đó tiếp tục clone currentStatSO đưa vào maxStatSO
    /// </summary>
    /// <exception cref="System.Exception"></exception>
    public void CloneStats()
    {
        if (currentStatSO != null)
        {
            currentStatSO = currentStatSO.GetCloneSO();
            maxStatSO = currentStatSO.GetCloneSO();
        }
        else if (maxStatSO != null)
        {
            maxStatSO = maxStatSO.GetCloneSO();
            currentStatSO = maxStatSO.GetCloneSO();
        }
        else
        {
            throw new System.Exception("NULL");
        }
    }

    public void UpdateMaxStat()
    {
        if (currentStatSO != null)
        {
            maxStatSO = currentStatSO.GetCloneSO();
        }
    }
}

