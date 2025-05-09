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
    public GameObject ItemDropPrefab;


    public void Damage(float damageAmount)
    {
        throw new System.NotImplementedException();
    }

    public void Disappear()
    {
        hostile.animator.Play(HostileAnimationHash.DisappearHash);
    }


    public void Revive()
    {
        throw new System.NotImplementedException();
    }

    public void Move(Vector2 movementVector2)
    {
        hostile.animator.Play(HostileAnimationHash.MoveHash);
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
        throw new System.NotImplementedException();
    }

    public override AbilitiesSO GetCloneSO()
    {
        HostileBasicAbilitiesSO cloneBasicAbilitiesSO = ScriptableObject.CreateInstance<HostileBasicAbilitiesSO>();
        cloneBasicAbilitiesSO.moveAbilitySO = (MoveAbilitySO)moveAbilitySO.GetCloneSO();
        cloneBasicAbilitiesSO.ItemDropPrefab = ItemDropPrefab;
        return cloneBasicAbilitiesSO;
    }

    public void DropItem()
    {

        XpGemSummonRift.instance.SummonXpGem(ItemDropPrefab, hostile.transform.position + new Vector3(-5, 0));
    }
}
