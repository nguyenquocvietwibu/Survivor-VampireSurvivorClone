using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Basic Abilities SO", menuName = "Scriptable Objects/Abilities/Hostile/Basic")]
public class HostileBasicAbilitiesSO : HostileAbilitesSO, IHostileBasicAbilities
{
    public event UnityAction MovePerformed;
    public event UnityAction DamagePerformed;
    public event UnityAction DisappearPerformed;
    public event UnityAction RevivePerformed;
    public event UnityAction IdlePerformed;
    public event UnityAction DiePerformed;

    public MoveAbilitySO moveAbilitySO;
    public void Damage(float damageAmount)
    {
        throw new System.NotImplementedException();
    }

    public void Disappear()
    {
        hostile.animator.Play(HostileAnimationHash.DisappearHash);
    }

    public void OnIdleExecute()
    {
        //hostile.animator.Play(hostile.idleHash);
        hostile.animator.speed = 0f;
        hostile.rigidBody2D.velocity = Vector2.zero;
    }

    public void OnMoveExecute(Vector2 movementVector2)
    {
        hostile.animator.speed = 1f;
        hostile.animator.Play(HostileAnimationHash.MoveHash);
        hostile.rigidBody2D.velocity = movementVector2;
    }

    public void Revive()
    {
        throw new System.NotImplementedException();
    }

    public void Move(Vector2 movementVector2)
    {
        moveAbilitySO.PerformMove(hostile.rigidBody2D, movementVector2);
    }

    public void Idle()
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator ProcessChaseSurvivor()
    {
        throw new System.NotImplementedException();
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }
}
