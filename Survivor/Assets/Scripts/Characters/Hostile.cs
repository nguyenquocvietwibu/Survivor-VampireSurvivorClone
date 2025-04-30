using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hostile : MonoBehaviour
{
    public GameObject trackedSurvivor;

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

    public HostileStats hostileStats;

    public HostileFlags hostileFlags;

    public GameObjectPool summonedGameObjectPool;
    void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        animator.Play(HostileAnimationHash.MoveHash);
        moveSpeed = 1f;
        smoothFactor = 1.0f;
        summonedTime = 0f;
    }

    private void Start()
    {
        trackedSurvivor = Survivor.Instance.gameObject;
        summonedGameObjectPool = GetComponentInParent<GameObjectPool>();
        if (summonedGameObjectPool == null )
        {
            throw new System.Exception("summonedPool is null");
        }
        hostileStats = GetComponent<HostileStats>();
        hostileFlags = GetComponent<HostileFlags>();
        
    }
    private void Update()
    {
        if (summonedTime >= 10f)
        {
            DisappearTosummonedGameObjectPoolActionTrigger?.Invoke(summonedGameObjectPool);
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
        rigidBody2D.velocity = Vector2.Lerp(rigidBody2D.velocity, directionVector2 * moveSpeed, Time.deltaTime * smoothFactor);
    }
}
