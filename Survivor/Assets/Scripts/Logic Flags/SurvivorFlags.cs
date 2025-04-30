using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// class mô tả các cờ logic kiểu boolean của Survivor
/// </summary>
public class SurvivorFlags : MonoBehaviour
{
    public bool canMove;
    public bool canDamage;
    public bool canAttack;

    public bool canHealthUp;
    public bool canAttackUp;
    public bool canMoveSpeedUp;
    public bool canDefenseUp;

    public bool canRecoveryAmountUp;
    public bool canProjectileAmountUp;
    public bool canRerollAmountUp;
    public bool canBanishAmountUp;
    public bool canSkipAmountUp;

    public bool canRecoveryTimeUp;

    public bool canGrowthRateUp;
    public bool canGreedRateUp;
    public bool canProjectileDurationRateUp;
    public bool canProjectileSpeedRateUp;
    public bool canProjectileDamageAreaRateUp;
    public bool canProjectileCoolDownRateUp;
    public bool canLuckRateUp;
    public bool canLifeStealRateUp;

    public bool isMoving;
    public bool isDamaged;
    public bool isDied;
    private void Awake()
    {
        canMove = true;
        canDamage = true;
        canAttack = true;

        canHealthUp = true;
        canAttackUp = true;
        canMoveSpeedUp = true;
        canDefenseUp = true;
        canRecoveryAmountUp = true;
        canRerollAmountUp = true;
        canBanishAmountUp = true;
        canSkipAmountUp = true;
        canProjectileAmountUp = true;

        canRecoveryTimeUp = true;

        canGrowthRateUp = true;
        canGreedRateUp = true;
        canProjectileDurationRateUp = true;
        canProjectileSpeedRateUp = true;
        canProjectileDamageAreaRateUp = true;
        canProjectileCoolDownRateUp = true;
        canLuckRateUp = true;
        canLifeStealRateUp = true;
    }
}
