using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Basic Abilities SO", menuName = "Scriptable Objects/Abilities/Hostile/Basic")]
public class HostileBaseAbilitiesSO : HostileAbilitesSO, IHostileBasicAbilities
{
    public event UnityAction MovePerformed;
    public event UnityAction DamagePerformed;
    public event UnityAction DisappearPerformed;
    public event UnityAction RevivePerformed;
    public event UnityAction IdlePerformed;
    public event UnityAction DiePerformed;

    public MoveAbilitySO moveAbilitySO;
    public GameObject ItemDropPrefab;

    public bool isDamaged;

    public bool canDamage;
    public bool canRevive;
    public bool canDisappear;
    public bool canDie;
    public bool canMove;
    public bool canAttack;

    public Coroutine restrictMovementProcess;
    public void Damage(float damageAmount)
    {
        Debug.Log("Hostile Damaged");
        if (canDamage)
        {
            isDamaged = true;
            hostile.statsManager.currentStatSO.SetStatValue(Stat.Health, hostile.statsManager.currentStatSO.GetStatValue(Stat.Health) - damageAmount);
            float currentHealth = hostile.statsManager.currentStatSO.GetStatValue(Stat.Health);
            if (currentHealth <= 0)
            {
                //Debug.Log("Disappear");
                Disappear();
            }
            else
            {
                hostile.stateMachineSO.SwitchState(hostile.statesManager.hitBackState);
            }
        }
    }

    public void Disappear()
    {
        hostile.stateMachineSO.SwitchState(hostile.statesManager.disappearState);
        canMove = false;
    }


    public void Revive()
    {
        hostile.statsManager.RestoreFullCurrentStats();
        RevivePerformed?.Invoke();

        hostile.stateMachineSO.SwitchState(hostile.statesManager.moveState);
    }

    public void Move(Vector2 movementVector2)
    {
        if (hostile.spriteRenderer.flipX && movementVector2.x > 0f)
        {
            hostile.spriteRenderer.flipX = false;
        }
        else if (!hostile.spriteRenderer.flipX && movementVector2.x < 0f)
        {
            hostile.spriteRenderer.flipX = true;
        }
        moveAbilitySO.PerformMove(hostile.rigidBody2D, movementVector2);
    }

    public void Idle()
    {
        hostile.rigidBody2D.velocity = Vector2.zero;
    }

    public IEnumerator ProcessChaseSurvivor()
    {
        throw new System.NotImplementedException();
    }

    public void Die()
    {
        hostile.summonedPool.GoInPool(hostile.gameObject);
    }

    public void KnockBack(Vector2 knockBackVector2)
    {
        if (hostile.rigidBody2D.velocity.magnitude < knockBackVector2.magnitude)
        {
            hostile.rigidBody2D.velocity = knockBackVector2;
        }
    }
    public override AbilitiesSO GetCloneSO()
    {
        HostileBaseAbilitiesSO cloneBasicAbilitiesSO = ScriptableObject.CreateInstance<HostileBaseAbilitiesSO>();
        cloneBasicAbilitiesSO.moveAbilitySO = (MoveAbilitySO)moveAbilitySO.GetCloneSO();
        cloneBasicAbilitiesSO.ItemDropPrefab = ItemDropPrefab;
        cloneBasicAbilitiesSO.canDamage = canDamage;
        cloneBasicAbilitiesSO.canDie = canDie;
        cloneBasicAbilitiesSO.canDisappear = canDisappear;
        cloneBasicAbilitiesSO.canRevive = canRevive;
        cloneBasicAbilitiesSO.canMove = canMove;
        cloneBasicAbilitiesSO.canAttack = canAttack;
        return cloneBasicAbilitiesSO;
    }

    public void DropItem()
    {

        XpGemSummonRift.instance.SummonXpGem(ItemDropPrefab, hostile.transform.position);
    }

    public IEnumerator ProcessRestrictMovement(float retrictMovementTime)
    {
        Debug.Log("ProcessRestrictMovement");
        Color grayColor = Color.gray;
        Color originColor = hostile.spriteRenderer.color;
        while (true)
        {
            if (isDamaged)
            {
                canMove = false;
                isDamaged = false;
                hostile.spriteRenderer.color = grayColor;
                yield return new WaitForSeconds(retrictMovementTime);
                canMove = true;
            }
            else
            {
                hostile.spriteRenderer.color = originColor;
                yield return null;
            }
        }
    }

    public void InitializeAbilites()
    {
        restrictMovementProcess = hostile.StartCoroutine(ProcessRestrictMovement(0.25f));
    }
}
