using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IMoveAbility
{
    public event UnityAction MovePerformed;
    public void Move(Vector2 movementVector2);
}
