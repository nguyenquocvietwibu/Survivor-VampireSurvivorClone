using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorStats : MonoBehaviour
{

    public SurvivorStatsSO statsSO;

    public float currentHealth;               // Current Health
    public float currentAttackPower;           // Current Attack Power
    public float currentMoveSpeed;              // Current Movement Speed
    public float currentDefense;               // Current Defense Value
    public float currentRecoveryAmount;         // Current Health Recovery Amount per Time
    public float currentRecoveryTime;           // Current Time Interval for Health Recovery
    public float currentGrowth;                 // Current Growth Rate
    public float currentGreed;                  // Current Greed
    public float currentProjectileDurationRate; // Current Projectile Duration Rate
    public float currentProjectileSpeedRate;  // Current Projectile Speed Rate
    public float currentProjectileAmount;       // Current Number of Projectiles Fired
    public float currentProjectileDamageAreaRate; // Current Projectile Damage Area Rate
    public float currentProjectileCoolDownRate; // Current Projectile Cooldown Rate
    public float currentRerollAmount;           // Current Reroll Amount
    public float currentBanishAmount;           // Current Banish Amount
    public float currentSkipAmount;             // Current Skip Amount
    public float currentLuckRate;               // Current Luck Rate
    public float currentLifeStealRate;          // Current Life Steal Rate

    private void Awake()
    {
        currentHealth = statsSO.health;
        currentAttackPower = statsSO.attackPower;
        currentMoveSpeed = statsSO.moveSpeed;
        currentDefense = statsSO.defense;
        currentRecoveryAmount = statsSO.recoveryAmount;
        currentRecoveryTime = statsSO.recoveryTime;
        currentGrowth = statsSO.growthRate;
        currentGreed = statsSO.greedRate;
        currentProjectileDurationRate = statsSO.projectileDurationRate;
        currentProjectileSpeedRate = statsSO.projectileSpeedRate;
        currentProjectileAmount = statsSO.projectileAmount;
        currentProjectileDamageAreaRate = statsSO.projectileDamageAreaRate;
        currentProjectileCoolDownRate = statsSO.projectileCoolDownRate;
        currentRerollAmount = statsSO.rerollAmount;
        currentBanishAmount = statsSO.banishAmount;
        currentSkipAmount = statsSO.skipAmount;
        currentLuckRate = statsSO.luckRate;
        currentLifeStealRate = statsSO.lifeStealRate;
    }
}
