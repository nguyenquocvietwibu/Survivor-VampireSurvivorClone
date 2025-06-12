using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fly Move Abilities SO", menuName = "Scriptable Objects/Abilities/General/Move/Fly Move")]
public class TheFlyAbilitySO : MoveAbilitySO
{
    public override void PerformMove(Rigidbody2D rigidBody2D, Vector2 movementVector2)
    {
        // Bước random nhỏ mỗi frame
        Vector2 brownian = new Vector2(
            (Random.value - 0.5f) * 2f,
            (Random.value - 0.5f) * 2f
        ) * 2f;  // biên độ drift

        rigidBody2D.velocity = movementVector2 + brownian;
    }



}
