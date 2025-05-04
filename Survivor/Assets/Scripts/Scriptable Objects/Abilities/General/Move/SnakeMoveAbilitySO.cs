using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Snake Move Abilities SO", menuName = "Scriptable Objects/Abilities/General/Move/Snake Move")]
public class SnakeMoveAbilitySO : MoveAbilitySO
{

    public float frequency = 3f;
    public float amplitude = 1f;

    public float accumulatedDistance = 0f;
    public Vector2 velocityVector2;
    public Vector2 perpendicularVector2;
    public override void PerformMove(Rigidbody2D rigidBody2D, Vector2 movementVector2)
    {
        // Tính hướng di chuyển chính (normalize để giữ độ dài vector là 1)
        Vector2 moveDirection = movementVector2.normalized;

        // Tính vector vuông góc với hướng di chuyển (cho chuyển động lắc lư)
        Vector2 perpendicular = new Vector2(-moveDirection.y, moveDirection.x);
        perpendicularVector2 = perpendicular;

        // Cập nhật khoảng cách tích lũy dựa trên tốc độ di chuyển
        float deltaDistance = movementVector2.magnitude * Time.deltaTime;
        accumulatedDistance += deltaDistance;

        // Tính giá trị sin dựa trên khoảng cách tích lũy và tần số
        float sinValue = Mathf.Sin(accumulatedDistance * frequency) * amplitude;

        // Tính vận tốc cuối cùng: hướng chính + chuyển động lắc lư
        Vector2 velocity = moveDirection * movementVector2.magnitude + perpendicular * sinValue;
        velocityVector2 = velocity;
        // Áp dụng vận tốc cho Rigidbody2D
        rigidBody2D.velocity = velocity;
    }
}
