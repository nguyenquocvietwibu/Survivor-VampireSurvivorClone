using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Snake Move Abilities SO", menuName = "Scriptable Objects/Abilities/General/Move/Snake Move")]
public class SnakeMoveAbilitySO : MoveAbilitySO
{

    private float _frequency = 3f;
    private float _amplitude = 1f;

  
    private Vector2 _velocityVector2;
    private Vector2 _perpendicularVector2;
    private float _accumulatedTime = 0.5f;

    public override void PerformMove(Rigidbody2D rigidBody2D, Vector2 movementVector2)
    {
        // Tính toán di chuyển theo hướng thẳng
        Vector2 moveDirection = movementVector2.normalized;
        Vector2 perpendicular = new(-moveDirection.y, moveDirection.x);
        _perpendicularVector2 = perpendicular;

        // Giữ biên độ và tần số không thay đổi
        _accumulatedTime += Time.deltaTime;

        // Tính toán dao động (sinValue) với biên độ không đổi
        float sinValue = Mathf.Sin(_accumulatedTime * _frequency) * _amplitude;

        // Tính toán vận tốc, không thay đổi biên độ và tần số
        Vector2 velocity = moveDirection * movementVector2.magnitude + perpendicular * sinValue;

        rigidBody2D.velocity = velocity;
    }
}
