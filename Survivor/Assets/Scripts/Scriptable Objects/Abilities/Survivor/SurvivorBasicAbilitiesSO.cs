using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Survivor Basic Abilities SO", menuName = "Scriptable Objects/Abilities/Survivor/Basic Abilities")]
public class SurvivorBasicAbilitiesSO : SurvivorAbilitiesSO, ISurvivorBasicAbilities
{
    public event UnityAction LevelUpPerformed;
    public event UnityAction IdlePerformed;
    public event UnityAction MovePerformed;
    public event UnityAction DamagePerformed;
    public event UnityAction RevivePerformed;
    public event UnityAction DisappearPerformed;
    public event UnityAction DiePerformed;

    public LevelUpAbilitySO levelUpAbilitySO;
    public MoveAbilitySO moveAbilitySO;
    public void Damage(float damageAmount)
    {
        survivor.statsSO.health -= damageAmount;
    }

    public void Die()
    {
        throw new System.NotImplementedException();
        DiePerformed?.Invoke();
    }

    public void Disappear()
    {
        survivor.animator.Play(SurvivorAnimationHash.disappearHash);
        DisappearPerformed?.Invoke();
    }

    public void GainXp(int xpAmount)
    {
        survivor.statsSO.experience += xpAmount;
        if (survivor.statsSO.experience == ILevelUpAbility.GetXpRequired(survivor.statsSO.level))
        {
            LevelUp();
        }
    }

    public void Idle()
    {
        survivor.animator.Play(SurvivorAnimationHash.idleHash);
        survivor.rigidBody2D.velocity = Vector2.zero;
        IdlePerformed?.Invoke();
    }

    public void LevelUp()
    {
        levelUpAbilitySO.PerformLevelUp(survivor.statsSO);
        LevelUpPerformed?.Invoke();
    }

    public void Move(Vector2 movementVector2)
    {
        if (survivor.spriteRenderer.flipX && movementVector2.x > 0f)
        {
            survivor.spriteRenderer.flipX = false;
        }
        else if (!survivor.spriteRenderer.flipX && movementVector2.x < 0f)
        {
            survivor.spriteRenderer.flipX = true;
        }
        survivor.animator.Play(SurvivorAnimationHash.moveHash);
        //survivor.rigidBody2D.velocity = movementVector2 * survivor.statsSO.moveSpeed;
        moveAbilitySO.PerformMove(survivor.rigidBody2D, movementVector2 * survivor.statsSO.moveSpeed);
        MovePerformed?.Invoke();
    }

    public void Revive()
    {
        throw new System.NotImplementedException();
        RevivePerformed?.Invoke();
    }

    public IEnumerator ProcessHurtbox()
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator ProcessTemporaryInivicibility(float invicibilityTime)
    {
        throw new System.NotImplementedException();
    }
}
