using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Class mô tả cho người sinh tồn (survivor) là nhân vật được điều khiển bởi input của bởi người chơi
/// </summary>
public class Survivor : MonoBehaviour, ISubstituteObject<Survivor>, IActionsObserver
{
    private static Survivor _instance;
    public static Survivor Instance { get => _instance; set => _instance = value; }

    public VirtualJoystick joystick;

    public CapsuleCollider2D capsuleCollider2D;
    public Animator animator;
    public Rigidbody2D rigidBody2D;
    public SpriteRenderer spriteRenderer;
    public float moveSpeed;

    public LayerMask checkCastLayerMask;
    public bool isFacingLeft;

    public UnityAction<Vector2> onMove;
    public UnityAction onIdle;
    public UnityAction onDisappear;
    public UnityAction onDie;
    public UnityAction<float> onDamage;
    public UnityAction onLevelUp;
    public UnityAction onRevive;


    public SurvivorUnityEventsSO unityEventsSO;
    public SurvivorStatsSO statsSO;
    public SurvivorFlagsSO flagsSO;
    public SurvivorAbilitiesSO abilitiesSO;

    public Coroutine coroutine;

    private bool _hasStarted;

    RaycastHit2D hit;


    public void SubscribeActions()
    {
        if (_hasStarted)
        {
            if (abilitiesSO is IMoveAbility moveAbility)
            {
                joystick.onMove += moveAbility.OnMoveExecute;
            }
            if (abilitiesSO is IIdleAbility idleAbility)
            {
                joystick.onIdle += idleAbility.OnIdleExecute;
            }
        }
    }

    public void UnSubscribeActions()
    {
        if (_hasStarted)
        {
            if (abilitiesSO is IMoveAbility moveAbility)
            {
                joystick.onMove -= moveAbility.OnMoveExecute;
            }
            if (abilitiesSO is IIdleAbility idleAbility)
            {
                joystick.onIdle -= idleAbility.OnIdleExecute;
            }
        }
    }
    public void ExecuteSubstitute(Survivor executedInstance)
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(_instance.gameObject);
            _instance = this;
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
        ExecuteSubstitute(this);

        moveSpeed = 2f;

        rigidBody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();

        unityEventsSO = Instantiate(unityEventsSO);
        statsSO = Instantiate(statsSO);
        flagsSO = Instantiate(flagsSO);
        abilitiesSO = Instantiate(abilitiesSO);
    }

    void Start()
    {
        _hasStarted = true;
        joystick = VirtualJoystick.Instance;

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Survivor"), LayerMask.NameToLayer("Hostile"), true);

        flagsSO.InitializeFlags();
        abilitiesSO.survivor = this;
        SubscribeActions();
    }


    // Update is called once per frame
    void Update()
    {
        CapsuleHurtBoxCast();
        //HurtboxCastAll();
    }

    public IEnumerator TakeDamageEveryTime(float damage, float time)
    {
        while (true)
        {
            if (flagsSO.canDamage)
            {

                if (statsSO.health > 0)
                {
                    statsSO.health -= Mathf.Abs((statsSO.defense - damage >= 0) ? 1 : statsSO.defense - damage);
                    Debug.Log((statsSO.defense - damage >= 0) ? 1 : statsSO.defense - damage);
                }
                else
                {
                    flagsSO.canMove = false;
                    animator.Play(SurvivorAnimationHash.DisappearHash);
                }
            }
            yield return new WaitForSeconds(time);
        }
    }

    public void CapsuleHurtBoxCast()
    {
        hit = Physics2D.CapsuleCast(capsuleCollider2D.bounds.center, capsuleCollider2D.bounds.size, capsuleCollider2D.direction, 0f, Vector2.zero, 0f, checkCastLayerMask);
        // Kiểm tra các đối tượng va chạm
        if (hit.collider != null)
        {
            flagsSO.isDamaged = true;
            onDamage?.Invoke(hit.collider.GetComponent<Hostile>().hostileStats.currentAttackPower);
        }
        else
        {
            flagsSO.isDamaged = false;
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
            coroutine = null;
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