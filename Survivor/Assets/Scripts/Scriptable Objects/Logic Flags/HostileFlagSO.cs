using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Hostile Flags SO", menuName = "Scriptable Objects/Logic Flags/Hostile")]
public class HostileFlagSO : ScriptableObject
{
    public bool canMove;
    public bool canDamage;
    public bool canAttack;

    public bool shouldChaseSurvivor;


    public bool isAlive;
    public bool isDisappeard;
}
