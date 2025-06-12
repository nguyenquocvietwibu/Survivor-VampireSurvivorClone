using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


/// <summary>
/// Class mô tả cho người sinh tồn (survivor) là nhân vật được điều khiển bởi input của bởi người chơi
/// </summary>
public class Survivor : MonoBehaviour
{

    [SerializeField] private CapsuleCollider2D _capsuleCollider2D;
    [SerializeField] private CapsuleCollider2D _hurtboxCapsuleCollider2D;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private StatsManager _statsManager;
    [SerializeField] private SurvivorStatesManager _survivorStatesManager;
    [SerializeField] private SurvivorAbilitiesManager _survivorAbilitiesManager;
    [SerializeField] private StateMachineSO _stateMachineSO;
    [SerializeField] private Vector2 _playerInputVector2;
    [SerializeField] private bool _hasStarted;


    public Rigidbody2D rigidBody2D => _rigidBody2D;
    public CapsuleCollider2D capsuleCollider2D => _capsuleCollider2D;
    public CapsuleCollider2D hurtBoxCapsuleCollider2D => _hurtboxCapsuleCollider2D;
    public Animator animator => _animator;
    public SpriteRenderer spriteRenderer => _spriteRenderer;
    public StatsManager statsManager => _statsManager;
    public StateMachineSO stateMachineSO => _stateMachineSO;
    public SurvivorStatesManager survivorStatesManager => _survivorStatesManager;
    public SurvivorAbilitiesManager survivorAbilitiesManager => _survivorAbilitiesManager;
    public Vector2 playerInputVector2 => _playerInputVector2;


   

    public void SubEvent()
    {
        VirtualJoystick.instance.joystickInputVector2Performed += OnPlayerInputVector2;
    }

    public void UnSubEvent()
    {
        VirtualJoystick.instance.joystickInputVector2Performed -= OnPlayerInputVector2;
    }

    private void OnEnable()
    {
        if (_hasStarted)
        {
            SubEvent();
        }
    }
    private void OnDisable()
    {
        if (_hasStarted)
        {
            UnSubEvent();
        }
    }

    private void Awake()
    {

        _rigidBody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        _statsManager = GetComponent<StatsManager>();
        _survivorStatesManager = GetComponent<SurvivorStatesManager>();
        _survivorAbilitiesManager = GetComponent<SurvivorAbilitiesManager>();

        _statsManager.CloneCurrentStatsAndMaxStats();
        _survivorStatesManager.ReceiveStates(this);
        _survivorAbilitiesManager.ReceiveSurvivorAbilities(this);
        _stateMachineSO = _stateMachineSO.GetCloneSO();
        _stateMachineSO.InitializeState(_survivorStatesManager.idleState);

        Camera.main.transform.parent = transform;

    }

    void Start()
    {
        _hasStarted = true;

        SubEvent();
    }


    // Update is called once per frame
    void Update()
    {
        _stateMachineSO.UpdateState();
       
    }

    public void OnPlayerInputVector2(Vector2 inputVector2)
    {
        _playerInputVector2 = inputVector2;
    }
    private void OnDrawGizmos()
    {
        if (_capsuleCollider2D == null)
        {
            return;
        }
        // Vẽ capsule collider dưới dạng hình tròn ở 2 đầu (dùng bán kính)
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(_capsuleCollider2D.bounds.center, new Vector2(_capsuleCollider2D.bounds.size.x, _capsuleCollider2D.bounds.size.y / 2));
        Gizmos.DrawWireSphere((Vector2)_capsuleCollider2D.bounds.center + new Vector2(0, _capsuleCollider2D.bounds.size.y / 4), _capsuleCollider2D.bounds.size.x / 2);  // Đỉnh của Capsule
        Gizmos.DrawWireSphere((Vector2)_capsuleCollider2D.bounds.center + new Vector2(0, -_capsuleCollider2D.bounds.size.y / 4), _capsuleCollider2D.bounds.size.x / 2); // Đáy của Capsule
    }
}