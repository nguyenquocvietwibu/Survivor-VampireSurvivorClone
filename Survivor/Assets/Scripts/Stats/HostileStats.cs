using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileStats : MonoBehaviour
{
    public HostileStatsSO statsSO;
    public float currentHealth;
    public float currentAttackPower;
    public float currentMoveSpeed;
    public float currentDefense;
    private void Awake()
    {
        currentHealth = statsSO.health;
        currentAttackPower = statsSO.attackPower;
        currentMoveSpeed = statsSO.moveSpeed;
        currentDefense = statsSO.defense;
    }
}
