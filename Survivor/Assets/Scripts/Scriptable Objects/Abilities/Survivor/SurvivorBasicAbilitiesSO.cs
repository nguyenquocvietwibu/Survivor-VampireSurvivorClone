using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Class mô tả các khả năng cơ bản của Survivor kèm một số khả năng đặc có thể khác biệt
/// </summary>
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


    public bool isDamaged;

    public bool canDamage;
    public bool canRevive;
    public bool canDisappear;
    public bool canDie;
    public bool canMove;

    public Coroutine invincibilityProcess;

    public void Damage(float damageAmount)
    {
        //survivor.statsSO.health -= damageAmount;
        if (canDamage)
        {
            survivor.statsManager.currentStatSO.SetStatValue(Stat.Health, survivor.statsManager.currentStatSO.GetStatValue(Stat.Health) - damageAmount);
            isDamaged = true;
        }
        
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

    public void GainXp(float xpAmount)
    {
        float currentXp = survivor.statsManager.currentStatSO.GetStatValue(Stat.Experience);
        float requireXp = ILevelUpAbility.GetXpRequired(survivor.statsManager.currentStatSO.GetStatValue(Stat.Level));
        survivor.statsManager.currentStatSO.SetStatValue(Stat.Experience, currentXp + xpAmount);
        currentXp = survivor.statsManager.currentStatSO.GetStatValue(Stat.Experience);
        while (currentXp >= requireXp)
        {
            Debug.Log("Level Up");
            LevelUp();
            currentXp -= requireXp;
            survivor.statsManager.currentStatSO.SetStatValue(Stat.Experience, currentXp);
        }
    }

    public void Idle()
    {
        survivor.rigidBody2D.velocity = Vector2.zero;
        IdlePerformed?.Invoke();
    }

    public void LevelUp()
    {
        levelUpAbilitySO.PerformLevelUp(survivor.statsManager.currentStatSO);
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
        moveAbilitySO.PerformMove(survivor.rigidBody2D, movementVector2 * survivor.statsManager.currentStatSO.GetStatValue(Stat.MoveSpeed));
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

    public IEnumerator ProcessInivicibility(float invicibilityTime)
    {
        while (true)
        {
            if (isDamaged)
            {
                canDamage = false;
                isDamaged = false;
                yield return new WaitForSeconds(invicibilityTime);
                canDamage = true;
            }
            yield return null;
        }
    }


    public override AbilitiesSO GetCloneSO()
    {
        SurvivorBasicAbilitiesSO cloneBasicAbilitiesSO = ScriptableObject.CreateInstance<SurvivorBasicAbilitiesSO>();
        cloneBasicAbilitiesSO.levelUpAbilitySO = (LevelUpAbilitySO)levelUpAbilitySO.GetCloneSO();
        cloneBasicAbilitiesSO.moveAbilitySO = (MoveAbilitySO)moveAbilitySO.GetCloneSO();
        cloneBasicAbilitiesSO.canDamage = canDamage;
        cloneBasicAbilitiesSO.canDie = canDie;
        cloneBasicAbilitiesSO.canDisappear = canDisappear;
        cloneBasicAbilitiesSO.canRevive = canRevive;
        cloneBasicAbilitiesSO.canMove = canMove;
        return cloneBasicAbilitiesSO;
    }

    public void InitializeAbilites()
    {
        
        invincibilityProcess = survivor.StartCoroutine(ProcessInivicibility(0.2f));
    }
}
