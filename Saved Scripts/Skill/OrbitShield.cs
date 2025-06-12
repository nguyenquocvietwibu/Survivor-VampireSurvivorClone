using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitShield : MonoBehaviour
{
    public float radius = 0.75f;     // Bán kính quay
    public float speed = 90f;    // Tốc độ quay (độ/giây)

    public Quaternion initialRotation;

    public StatsManager statsManager;

    private bool _hasStarted;

    public GameObjectPool orbitShieldPool;

    public CapsuleCollider2D capsuleCollider2D;
    
    private float _maxSize;
    private float _growthSpeed;
    private void OnEnable()
    {
        
        if (_hasStarted)
        {
            transform.localScale = Vector3.zero;
            //Debug.Log(statsManager.currentStatSO.GetStatValue(Stat.sizeRate));
            _maxSize = statsManager.currentStatSO.GetStatValue(Stat.sizeRate) / 100f;
        }
    }

    private void OnDisable()
    {
        if (_hasStarted)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void Awake()
    {
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        orbitShieldPool = GetComponentInParent<GameObjectPool>();
    }
    void Start()
    {
        _hasStarted = true;
        transform.localScale = Vector3.zero;
        _growthSpeed = 2f;
        
    }

    float elapseTime = 0;
    void Update()
    {
        
        elapseTime += Time.deltaTime;
        if (elapseTime >= statsManager.currentStatSO.GetStatValue(Stat.LifeTime))
        {
            float scale = transform.localScale.x - _growthSpeed * Time.deltaTime;
            _maxSize = statsManager.currentStatSO.GetStatValue(Stat.sizeRate) / 100f;
            scale = Mathf.Clamp(scale, 0f, _maxSize);
            transform.localScale = new Vector3(scale, scale, 0f);
            if (transform.localScale.x <= 0f)
            {
                orbitShieldPool.GoInPool(gameObject);
                elapseTime = 0;
            }
        }
        else
        {
            float scale = transform.localScale.x + _growthSpeed * Time.deltaTime;
            _maxSize = statsManager.currentStatSO.GetStatValue(Stat.sizeRate) / 100f;
            scale = Mathf.Clamp(scale, 0f, _maxSize);
            transform.localScale = new Vector3(scale, scale, 0f);

        }
        // Di chuyển đối tượng theo vòng tròn quanh player
        transform.RotateAround(transform.parent.position, Vector3.forward, speed * Time.deltaTime);
        // Đảm bảo rotation không thay đổi, giữ nguyên góc ban đầu
        transform.rotation = initialRotation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hostile"))
        {

            //Vector2 forceDirectionVector2 = collision.transform.position - Survivor.instance.transform.position;

            //Hostile tempHostile = collision.GetComponent<Hostile>();
            //tempHostile.basicAbilitiesSO.Damage(Survivor.instance.statsManager.currentStatSO.GetStatValue(Stat.AttackPower) * statsManager.currentStatSO.GetStatValue(Stat.AttackMultiplier));
            //tempHostile.basicAbilitiesSO.KnockBack(forceDirectionVector2.normalized * 2f);
            //Debug.Log("shield attack hostile");
        }
    }
}
