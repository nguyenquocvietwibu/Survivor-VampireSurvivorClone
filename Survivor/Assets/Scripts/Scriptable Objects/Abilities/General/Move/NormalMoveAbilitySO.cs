using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Normal Move Abilities SO", menuName = "Scriptable Objects/Abilities/General/Move/Normal Move")]
public class NormalMoveAbilitySO : MoveAbilitySO
{
    public override AbilitySO GetCloneSO()
    {
        return Instantiate<NormalMoveAbilitySO>(this);
    }

    public override void PerformMove(Rigidbody2D rigidBody2D, Vector2 movementVector2)
    {
        rigidBody2D.velocity = movementVector2;
    }
}
