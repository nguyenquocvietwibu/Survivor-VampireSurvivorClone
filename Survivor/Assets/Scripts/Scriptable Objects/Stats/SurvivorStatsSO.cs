using UnityEngine;

[CreateAssetMenu(fileName = "New Survivor Stats SO", menuName = "Scriptable Objects/Stats/Survivor")]
public class SurvivorStatsSO : ScriptableObject
{
    public float health = 100;
    public float attackPower = 10;
    public float moveSpeed = 2;
    public float defense = 10;

    public float growthRate = 0;
    public float greedRate = 0;

    public float recoveryAmount = 1;
    public float rerollAmount = 0;
    public float banishAmount = 0;
    public float skipAmount = 0;
    public float projectileAmount = 1;

    public float recoveryTime = 5;



    public float projectileDurationRate = 100;
    public float projectileSpeedRate = 100;
    public float projectileDamageAreaRate = 100;
    public float projectileCoolDownRate = 100;
    public float luckRate = 0;
    public float lifeStealRate = 0;


}
