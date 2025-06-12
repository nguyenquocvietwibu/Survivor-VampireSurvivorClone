using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesManager : MonoBehaviour
{
    public AbilitiesSO abilitiesSO;

    public void CloneAbilites()
    {
        if (abilitiesSO == null)
        {
            throw new System.Exception("NULL AbilitesSO");
        }
        else
        {
            abilitiesSO = abilitiesSO.GetCloneSO();
        }
    }
}
