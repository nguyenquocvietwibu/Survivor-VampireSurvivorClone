using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveAbilitySO : AbilitySO, ICloneScriptableObjectAbility<MoveAbilitySO>
{
    public MoveAbilitySO GetCloneSO()
    {
        return ScriptableObject.CreateInstance<MoveAbilitySO>();
    }

    public abstract void PerformMove(Rigidbody2D rigidBody2D, Vector2 movementVector2);
}
