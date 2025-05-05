using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveAbilitySO : AbilitySO
{
    public abstract void PerformMove(Rigidbody2D rigidBody2D, Vector2 movementVector2);
}
