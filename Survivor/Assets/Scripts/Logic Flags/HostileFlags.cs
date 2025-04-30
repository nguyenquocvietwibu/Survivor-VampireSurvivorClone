using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileFlags : MonoBehaviour
{
    public bool canMove;
    public bool canDamage;
    public bool canAttack;

    public bool isDied;
    private void Awake()
    {
        canMove = true;
        canDamage = true;
        canAttack = true;
    }
}
