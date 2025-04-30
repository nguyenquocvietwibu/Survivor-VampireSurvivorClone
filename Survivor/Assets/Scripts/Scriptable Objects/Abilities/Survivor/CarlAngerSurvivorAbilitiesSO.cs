using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Carl Anger Survivor Abilities SO", menuName = "Scriptable Objects/Abilities/Survivor/Carl Anger")]
public class CarlAngerSurvivorAbilitiesSO : SurvivorAbilitiesSO, IFixedStatsAbility, ILevelUpBonusAbility, ISurvivorBasicAbility
{

    public void ExecuteFixedStats()
    {
        survivor.flagsSO.canDefenseUp = false;
    }

    public void OnDamagExecute(float damageAmount)
    {
        if (survivor.flagsSO.canDamage)
        {
            if (survivor.statsSO.health >= 1f)
            {
                survivor.statsSO.health -= damageAmount;
                if (survivor.statsSO.health <= 0)
                {
                    survivor.onDie?.Invoke();
                }
            }
        }
    }

    public void OnDieExecute()
    {
        throw new System.NotImplementedException();
    }

    public void OnIdleExecute()
    {
        survivor.animator.Play(SurvivorAnimationHash.IdleHash);
        survivor.rigidBody2D.velocity = Vector2.zero * survivor.statsSO.moveSpeed;
    }

    public void OnLevelUpBonusExecute()
    {
        survivor.statsSO.attackPower += 3;
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
        throw new System.NotImplementedException();
    }

    public IEnumerator PerformTemporaryInivicibility(float invicibilityTime)
    {
        while (true)
        {
            survivor.flagsSO.canDamage = false;
            yield return new WaitForSeconds(invicibilityTime);
            survivor.flagsSO.canDamage = true;
        }
    }
}
