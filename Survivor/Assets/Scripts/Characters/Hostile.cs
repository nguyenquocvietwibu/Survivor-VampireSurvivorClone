using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Lớp mô tả hostile thù địch của survivor
/// </summary>
public class Hostile : MonoBehaviour, IActionsObserver
{
    public Survivor trackedSurvivor;

    public float moveSpeed;
    public float smoothFactor; // càng cao thì càng dí sát

    public CapsuleCollider2D capsuleCollider2D;
    public CapsuleCollider2D hitboxCapsuleCollider2D;
    public Rigidbody2D rigidBody2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public Vector2 directionVector2;

    public bool isFacingLeft;

    public VirtualJoystick joystick;

    public float summonedTime;

    public UnityAction<GameObjectPool> DisappearTosummonedGameObjectPoolActionTrigger;
    public UnityAction onAlive;
    public UnityAction<Vector2> onMove;
    public UnityAction onSurvivorChase;
    public UnityAction onDisappear;
    public UnityAction onStun;
    public UnityAction onIdle;

    public HostileFlagSO flagSO;

    public GameObjectPool summonedPool;

    public StatsManager statsManager;

    public HostileStatesManager statesManager;

    public bool hasStarted;

    public AbilitiesManager abilitiesManager;
    //public IHostileBasicAbilities basicAbilities;
    public HostileBasicAbilitiesSO basicAbilitiesSO;

    public void SubscribeActions()
    {
        if (hasStarted)
        {
            //if (abilitesSO is IHostileBasicAbilities basicAbilities)
            //{

            //}
            
        }
    }

    public void UnSubscribeActions()
    {
        if (hasStarted)
        {

        }
    }

    private void OnEnable()
    {
        SubscribeActions();
    }

    private void OnDisable()
    {
        UnSubscribeActions();
    }
    void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        statsManager = GetComponent<StatsManager>();
        abilitiesManager = GetComponent<AbilitiesManager>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();

        if (rigidBody2D == null || animator == null || spriteRenderer == null)
        {
            throw new Exception("Component NULL");
        }

        if (abilitiesManager != null)
        {
            abilitiesManager.CloneAbilites();
        }

        if (statsManager != null)
        {
            statsManager.CloneStats();
        }

        if (abilitiesManager.abilitiesSO is HostileBasicAbilitiesSO tempBasicAbilitiesSO)
        {
            abilitiesManager.abilitiesSO.ReceiveAbility(this);
            basicAbilitiesSO = tempBasicAbilitiesSO;
        }
        else
        {
            throw new System.Exception("NULL Hostile abilitesSO");
        }

        statesManager = GetComponent<HostileStatesManager>();

        moveSpeed = 1f;
        smoothFactor = 1.0f;
        summonedTime = 0f;

        //if (summonedPool == null)
        //{
        //    throw new System.Exception("summonedGOPool is null");
        //}

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Hostile"), LayerMask.NameToLayer("Hostile"), true);
        
    }

    private void Start()
    {
        hasStarted = true;
        trackedSurvivor = Survivor.instance;
        if (trackedSurvivor == null)
        {
            throw new System.Exception("NULL");
        }

        summonedPool = GetComponentInParent<GameObjectPool>();

        flagSO = Instantiate(flagSO);

        SubscribeActions();

        Physics2D.IgnoreCollision(capsuleCollider2D, Survivor.instance.capsuleCollider2D);
    }
    private void Update()
    {
        if (summonedTime >= 10f)
        {
            DisappearTosummonedGameObjectPoolActionTrigger?.Invoke(summonedPool);
        }
        directionVector2 = (trackedSurvivor.transform.position - transform.position).normalized;

        if (isFacingLeft && directionVector2.x >= 0)
        {
            isFacingLeft = false;
            spriteRenderer.flipX = isFacingLeft;
        }
        else if (!isFacingLeft && directionVector2.x <= 0)
        {
            isFacingLeft = true;
            spriteRenderer.flipX = isFacingLeft;
        }
        // Mượt hóa vận tốc để không bị "bấu víu"

        //rigidBody2D.velocity = Vector2.Lerp(rigidBody2D.velocity, directionVector2 * statsManager.currentStatSO.GetStatValue(Stat.MoveSpeed), Time.deltaTime * smoothFactor);
        //basicAbilities.Move(Vector2.Lerp(rigidBody2D.velocity, directionVector2 * statsManager.currentStatSO.GetStatValue(Stat.MoveSpeed), Time.deltaTime * smoothFactor));
        basicAbilitiesSO.Move(Vector2.Lerp(rigidBody2D.velocity, directionVector2 * statsManager.currentStatSO.GetStatValue(Stat.MoveSpeed), 1));

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.CompareTag("Survivor"))
    //    {
    //        Debug.Log("Attack Player");
    //        Survivor.instance.basicAbilitiesSO.Damage(statsManager.currentStatSO.GetStatValue(Stat.AttackPower));
    //    }
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Survivor"))
        {
            Debug.Log("Attack Player");
            Survivor.instance.basicAbilitiesSO.Damage(statsManager.currentStatSO.GetStatValue(Stat.AttackPower));
            Debug.Log(statsManager.currentStatSO.GetStatValue(Stat.AttackPower));
            Die();
        }
    }

    private bool _isDied;
    public void Die()
    {
        if (!_isDied)
        {
            basicAbilitiesSO.DropItem();
        }
        _isDied = true;
    }

    public void OnSurvivorChase()
    {
        
    }

}
