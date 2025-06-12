using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IMoveAble
{
    public event UnityAction MovePerformed;

    public MoveAbilitySO MoveAbilitySO { get; set; }
    public bool CanMove { get; set; }
    public void Move(float movementVector2);
}
