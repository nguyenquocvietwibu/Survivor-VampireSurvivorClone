using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class SurvivorBaseAbilites : ISurvivorBaseAbilites
{
    [SerializeField] private bool _canMove;
    [SerializeField] private bool isDead;
    [SerializeField] private bool _canDamaged;
    [SerializeField] private Survivor _survivor;
    [SerializeField] private MoveAbilitySO _moveAbilitySO;
    public bool CanMove { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool IsDead { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool IsDamaged { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool CanDamage { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public Survivor survivor => _survivor;

    public MoveAbilitySO MoveAbilitySO { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public event UnityAction MovePerformed;
    public event UnityAction DamagePerformed;
    public event UnityAction DiePerformed;
    public event UnityAction RevivePerformed;


    public SurvivorBaseAbilites(Survivor survivor)
    {
        Debug.Log(_canMove);
        Debug.Log(_moveAbilitySO);
        _survivor = survivor;
        _moveAbilitySO = _moveAbilitySO.GetCloneSO();

    }
    public void Damage(float damageAmount)
    {
        throw new System.NotImplementedException();
    }

    public void Die()
    {
        throw new System.NotImplementedException();
    }

    public void Move(float movementVector2)
    {
        throw new System.NotImplementedException();
    }

    public void ReceiveAbilities(Survivor receivedMonobehavior)
    {
        _survivor = receivedMonobehavior;
    }

    public void Revive()
    {
        _canMove = true;
        _survivor.statsManager.RestoreFullCurrentStats();
    }
}
