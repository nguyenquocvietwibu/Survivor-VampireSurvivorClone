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

    public CharacterStatsSO statsSO;
    public CharacterStatsSO initialstatsSO;

    public HostileAbilitesSO abilitesSO;

    public HostileFlagSO flagSO;

    public GameObjectPool summonedPool;

    public bool hasStarted;

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

        animator.Play(HostileAnimationHash.MoveHash);
        moveSpeed = 1f;
        smoothFactor = 1.0f;
        summonedTime = 0f;

        //if (summonedPool == null)
        //{
        //    throw new System.Exception("summonedGOPool is null");
        //}

        if (statsSO == null)
        {
            throw new System.Exception("hostileStatsSO == null");
        }

        if (abilitesSO == null)
        {
            throw new System.Exception("abilitesSO == null");
        }
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

        initialstatsSO = statsSO;
        statsSO = Instantiate(statsSO);
        flagSO = Instantiate(flagSO);
        abilitesSO = Instantiate(abilitesSO);
        abilitesSO.hostile = this;

        SubscribeActions();
        
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

        onMove?.Invoke(Vector2.Lerp(rigidBody2D.velocity, directionVector2 * moveSpeed, Time.deltaTime * smoothFactor));
    }

    public void OnSurvivorChase()
    {
        
    }

}
