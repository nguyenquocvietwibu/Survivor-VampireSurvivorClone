using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Survivor Flags SO", menuName = "Scriptable Objects/Logic Flags/Survivor")]
public class SurvivorFlagsSO : ScriptableObject
{
    public bool canMove;
    public bool canDamage;
    public bool canAttack;
    public bool canRevive;

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
    public bool isFacingLeft;
    public bool isDisappeared;
    public bool isAlive;

}
