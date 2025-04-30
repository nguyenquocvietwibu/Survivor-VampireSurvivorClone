using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hostile Stats", menuName = "Scriptable Objects/Stats/Hostile")]
public class HostileStatsSO : ScriptableObject
{
    public float health = 10;
    public float moveSpeed = 1;
    public float attackPower = 10;
    public float defense = 0;
}
