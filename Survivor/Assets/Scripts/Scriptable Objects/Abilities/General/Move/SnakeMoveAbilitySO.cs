using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Snake Move Abilities SO", menuName = "Scriptable Objects/Abilities/General/Move/Snake Move")]
public class SnakeMoveAbilitySO : MoveAbilitySO
{

    public float frequency = 3f;
    public float amplitude = 1f;

  
    public Vector2 velocityVector2;
    public Vector2 perpendicularVector2;
    public float accumulatedTime = 0.5f;

    public override AbilitySO GetCloneSO()
    {
        return Instantiate<SnakeMoveAbilitySO>(this);
    }

    public override void PerformMove(Rigidbody2D rigidBody2D, Vector2 movementVector2)
    {
        // Tính toán di chuyển theo hướng thẳng
        Vector2 moveDirection = movementVector2.normalized;
        Vector2 perpendicular = new(-moveDirection.y, moveDirection.x);
        perpendicularVector2 = perpendicular;

        // Giữ biên độ và tần số không thay đổi
        accumulatedTime += Time.deltaTime;

        // Tính toán dao động (sinValue) với biên độ không đổi
        float sinValue = Mathf.Sin(accumulatedTime * frequency) * amplitude;

        // Tính toán vận tốc, không thay đổi biên độ và tần số
        Vector2 velocity = moveDirection * movementVector2.magnitude + perpendicular * sinValue;

        rigidBody2D.velocity = velocity;
    }
}
