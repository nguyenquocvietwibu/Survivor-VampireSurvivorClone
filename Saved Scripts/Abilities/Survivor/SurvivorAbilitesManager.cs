using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorAbilitiesManager : MonoBehaviour
{
    [SerializeField] private SurvivorBaseAbilites _survivorBaseAbilites;

    public SurvivorBaseAbilites survivorBaseAbilites { get => _survivorBaseAbilites; set => _survivorBaseAbilites = value; }
    public void ReceiveSurvivorAbilities(Survivor receivedSurvivor)
    {
        _survivorBaseAbilites = new(receivedSurvivor);
    }
}
