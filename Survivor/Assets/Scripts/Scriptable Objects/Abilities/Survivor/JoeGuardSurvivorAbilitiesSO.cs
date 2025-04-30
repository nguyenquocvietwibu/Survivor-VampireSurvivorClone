using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Joe Guard Survivor Abilities SO", menuName = "Scriptable Objects/Abilities/Survivor/Joe Guard")]
public class JoeGuardSurvivorAbilitiesSO : SurvivorAbilitiesSO, ILevelUpBonusAbility, ISurvivorBasicAbility
{
    public void OnDamagExecute(float damageAmount)
    {
        if (survivor.flagsSO.canDamage)
        { 
            if (survivor.statsSO.health >= 1f)
            {
                survivor.statsSO.health -= Mathf.Abs((survivor.statsSO.defense - damageAmount >= 0) ? 1 : survivor.statsSO.defense - damageAmount);
                Debug.Log((survivor.statsSO.defense - damageAmount >= 0) ? 1 : survivor.statsSO.defense - damageAmount);
                if (survivor.statsSO.health <= 0)
                {
                    survivor.onDie?.Invoke();
                }
            }
        }
    }

    public void OnDieExecute()
    {
        survivor.flagsSO.canMove = false;
        survivor.animator.Play(SurvivorAnimationHash.DisappearHash);
    }

    public void OnIdleExecute()
    {
        survivor.animator.Play(SurvivorAnimationHash.IdleHash);
        survivor.rigidBody2D.velocity = Vector2.zero * survivor.statsSO.moveSpeed;
    }

    public void OnLevelUpBonusExecute()
    {
        survivor.statsSO.attackPower += 1;
        survivor.statsSO.defense += 1;
    }

    public void OnLevelUpExecute()
    {
        throw new System.NotImplementedException();
    }

    public void OnMoveExecute(Vector2 movementVector2)
    { 
        if (survivor.flagsSO.canMove)
        {
            survivor.rigidBody2D.velocity = movementVector2;
            if (survivor.isFacingLeft && movementVector2.x >= 0f)
            {
                survivor.isFacingLeft = false;
                survivor.spriteRenderer.flipX = survivor.isFacingLeft;

            }
            else if (!survivor.isFacingLeft && movementVector2.x <= 0f && survivor.flagsSO.canMove)
            {
                survivor.isFacingLeft = true;
                survivor.spriteRenderer.flipX = survivor.isFacingLeft;
            }
            survivor.animator.Play(SurvivorAnimationHash.MoveHash);
        }
    }

    public void OnReviveExecute()
    {
        survivor.flagsSO.canMove = true;
        Debug.Log("Revived!");
    }

    public IEnumerator PerformTemporaryInivicibility(float invicibilityTime)
    {
        throw new System.NotImplementedException();
    }
}
