using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorComponentsManger : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private CapsuleCollider2D _bodyCapsuleCollider2D;
    [SerializeField] private CapsuleCollider2D _hurtboxCapsuleCollider2D;

    public Rigidbody2D rigidBody2D => _rigidBody2D;
    public SpriteRenderer spriteRenderer => _spriteRenderer;
    public Animator animator => _animator;
    public CapsuleCollider2D bodyCapsuleCollider2D => _bodyCapsuleCollider2D;
}
