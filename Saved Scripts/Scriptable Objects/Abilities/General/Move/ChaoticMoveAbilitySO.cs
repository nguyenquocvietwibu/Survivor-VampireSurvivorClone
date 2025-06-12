using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Chaotic Move Abilities SO", menuName = "Scriptable Objects/Abilities/General/Move/Chaotic Move")]
public class ChaoticMoveAbilitySO : MoveAbilitySO
{

    private float _changeTime = 0f;
    private Vector2 _offset = Vector2.zero;

    public override void PerformMove(Rigidbody2D rigidBody2D, Vector2 movementVector2)
    {
        if (Time.time > _changeTime)
        {
            _offset = Quaternion.Euler(0, 0, Random.Range(-90f, 90f)) * movementVector2.normalized;
            _changeTime = Time.time + Random.Range(0.5f, 1.5f);
        }
        rigidBody2D.velocity = movementVector2 + _offset;
    }
}
