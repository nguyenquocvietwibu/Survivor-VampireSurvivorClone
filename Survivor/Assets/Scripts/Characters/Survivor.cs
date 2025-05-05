using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Class mô tả cho người sinh tồn (survivor) là nhân vật được điều khiển bởi input của bởi người chơi
/// </summary>
public class Survivor : MonoBehaviour, ISubstituteObject<Survivor>, IActionsObserver
{
    public static Survivor instance;

    public VirtualJoystick joystick;

    public CapsuleCollider2D capsuleCollider2D;
    public Animator animator;
    public Rigidbody2D rigidBody2D;
    public SpriteRenderer spriteRenderer;

    public float moveSpeed;

    public LayerMask checkCastLayerMask;
    public bool isFacingLeft;
    public SurvivorFlagsSO flagsSO;
    public ISurvivorBasicAbilities basicAbilities;
    public AbilitiesManager abilitiesManager;
    public StatsSO oStatsSO;

    public StatsManager statsManager;

    public Coroutine coroutine;


    private bool _hasStarted;

    public void SubscribeActions()
    {
        if (_hasStarted)
        {
           
        }
    }

    public void UnSubscribeActions()
    {
        if (_hasStarted)
        {
            
        }
    }
    public void PerformSubstitute(Survivor executedInstance)
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
            instance = this;
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

    private void Awake()
    {
        PerformSubstitute(this);

        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();


        if (rigidBody2D == null || capsuleCollider2D == null || animator == null || spriteRenderer == null)
        {
            throw new Exception("Component NULL");
        }

        flagsSO = Instantiate(flagsSO);

        if (abilitiesManager.abilitiesSO is ISurvivorBasicAbilities tempBasicAbilities)
        {
            Debug.Log("SDSD");
            abilitiesManager.abilitiesSO.ReceiveAbility(this);
            basicAbilities = tempBasicAbilities;
        }
        else
        {
            throw new Exception("Survivor Abilites NULL");
        }

        Camera.main.transform.parent = transform;

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Survivor"), LayerMask.NameToLayer("Hostile"), true);
    }

    void Start()
    {
        _hasStarted = true;


        statsManager = GetComponent<StatsManager>();
        abilitiesManager = GetComponent<AbilitiesManager>();


       

        joystick = VirtualJoystick.instance;

        SubscribeActions();
    }


    // Update is called once per frame
    void Update()
    {
        if (joystick.isJoystickMove)
        {
            basicAbilities.Move(joystick.joystickVector2);
        }
        else if (joystick.isJoystickUp)
        {
            basicAbilities.Idle();
        }
    }
    public void OnAliveCapsuleHurtBoxCast()
    {
        RaycastHit2D hit2D = Physics2D.CapsuleCast(capsuleCollider2D.bounds.center, capsuleCollider2D.bounds.size, capsuleCollider2D.direction, 0f, Vector2.zero, 0f, checkCastLayerMask);
        // Kiểm tra các đối tượng va chạm
        if (hit2D.collider != null)
        {

        }
        else
        {
            flagsSO.isDamaged = false;
        }
    }
    private void OnDrawGizmos()
    {
        if (capsuleCollider2D == null)
        {
            return;
        }



        // Vẽ capsule collider dưới dạng hình tròn ở 2 đầu (dùng bán kính)
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(capsuleCollider2D.bounds.center, new Vector2(capsuleCollider2D.bounds.size.x, capsuleCollider2D.bounds.size.y / 2));
        Gizmos.DrawWireSphere((Vector2)capsuleCollider2D.bounds.center + new Vector2(0, capsuleCollider2D.bounds.size.y / 4), capsuleCollider2D.bounds.size.x / 2);  // Đỉnh của Capsule
        Gizmos.DrawWireSphere((Vector2)capsuleCollider2D.bounds.center + new Vector2(0, -capsuleCollider2D.bounds.size.y / 4), capsuleCollider2D.bounds.size.x / 2); // Đáy của Capsule
    }
}