using UnityEngine;

[CreateAssetMenu(fileName = "New Character Stats SO", menuName = "Scriptable Objects/Stats/Character")]
public class CharacterStatsSO : ScriptableObject
{
    public int level;
    public int experience;

    public float health;
    public float attackPower;
    public float moveSpeed;
    public float defense;

    public float recoveryAmount;
    public float rerollAmount;

    public float banishQuantity;
    public float skipQuantity;
    public float projectileQuantity;

    public float recoveryTime;

    public float growthRate;
    public float greedRate;
    public float projectileDurationRate;
    public float projectileSpeedRate;
    public float projectileDamageAreaRate;
    public float projectileCoolDownRate;
    public float luckRate;
    public float lifeStealRate;
}
