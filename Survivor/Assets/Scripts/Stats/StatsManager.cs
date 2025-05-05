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

    private void Awake()
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

