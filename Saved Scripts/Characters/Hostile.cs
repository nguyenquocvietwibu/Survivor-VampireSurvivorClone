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

    public GameObjectPool summonedPool;

    public StatsManager statsManager;

    public HostileStatesManager statesManager;

    public StateMachineSO stateMachineSO;

    public bool hasStarted;

    public AbilitiesManager abilitiesManager;
    //public IHostileBasicAbilities basicAbilities;
    public HostileBaseAbilitiesSO basicAbilitiesSO;

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
        if (hasStarted)
        {
            basicAbilitiesSO.InitializeAbilites();
            basicAbilitiesSO.Revive();
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Hostile"), LayerMask.NameToLayer("Hostile"), true);
            //Physics2D.IgnoreCollision(capsuleCollider2D, Survivor.instance.capsuleCollider2D);
        }
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
        statesManager = GetComponent<HostileStatesManager>();

        if (rigidBody2D == null || animator == null || spriteRenderer == null)
        {
            throw new Exception("Component NULL");
        }

        abilitiesManager.CloneAbilites();

        statsManager.CloneCurrentStatsAndMaxStats();

        if (abilitiesManager.abilitiesSO is HostileBaseAbilitiesSO tempBasicAbilitiesSO)
        {
            abilitiesManager.abilitiesSO.ReceiveAbiliies(this);
            basicAbilitiesSO = tempBasicAbilitiesSO;

        }

        statesManager.ReceiveState(this);

        stateMachineSO = stateMachineSO.GetCloneSO();
        stateMachineSO.InitializeState(statesManager.moveState);
        stateMachineSO.currrenStateName = stateMachineSO.currentStateBehavior.ToString();

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
        //trackedSurvivor = Survivor.instance;
        if (trackedSurvivor == null)
        {
            throw new System.Exception("NULL");
        }

        summonedPool = GetComponentInParent<GameObjectPool>();
        //Physics2D.IgnoreCollision(capsuleCollider2D, Survivor.instance.capsuleCollider2D);
        basicAbilitiesSO.InitializeAbilites();
        SubscribeActions();

    }
    private void Update()
    {
        stateMachineSO.UpdateState();
        if (summonedTime >= 10f)
        {
            DisappearTosummonedGameObjectPoolActionTrigger?.Invoke(summonedPool);
        }
        

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
            if (basicAbilitiesSO.canAttack)
            {
                Debug.Log("Attack Player");
                //Survivor.instance.basicAbilitiesSO.Damage(statsManager.currentStatSO.GetStatValue(Stat.AttackPower));
                //Debug.Log(statsManager.currentStatSO.GetStatValue(Stat.AttackPower));
            }
        }
    }


}
