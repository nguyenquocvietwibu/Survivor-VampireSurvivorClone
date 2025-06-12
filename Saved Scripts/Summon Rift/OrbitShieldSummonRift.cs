using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OrbitShieldSummonRift : MonoBehaviour, ISubstitute<OrbitShieldSummonRift>, ILevelUpAbility
{
    public static OrbitShieldSummonRift instance;

    public GameObjectPool orbitShieldPool;

    public event UnityAction LevelUpPerformed;

    public StatsManager statsManager;

    public bool canSummon;

    public float summonRadius;

    public GameObject tempOrbitShieldGO;

    public Coroutine coolDownProcess;

    public bool _hasStarted;

    private bool _isSummoned;
    public void LevelUp()
    {
        
    }

    public void PerformSubstitute(OrbitShieldSummonRift executedInstance)
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
        if (_hasStarted)
        {

        }
    }

    private void OnDisable()
    {
        if (!_hasStarted)
        {

        }
    }

    private void Awake()
    {      
        PerformSubstitute(this);

        summonRadius = 0.75f;

        statsManager = GetComponent<StatsManager>();
        statsManager.CloneCurrentStatsAndMaxStats();

        orbitShieldPool = GetComponent<GameObjectPool>();
        orbitShieldPool.PreWarm(20, orbitShieldPool.transform);

        foreach (GameObject orbitShieldGO in orbitShieldPool.pooledGOStack)
        {
            orbitShieldGO.GetComponent<OrbitShield>().statsManager = statsManager;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        _hasStarted = true;
        //orbitShieldPool.GoOutPool(orbitShieldPool.transform);
        canSummon = true;
        SummonOrbitShields();
        coolDownProcess = StartCoroutine(ProcessCoolDown());
    }

    // Update is called once per frame
    void Update()
    {
        if (canSummon)
        {
            SummonOrbitShields();
        }
    }

    /// <summary>
    /// IEnumerator xử lý quá trình cool down hồi chiêu
    /// </summary>
    /// <returns></returns>
    public IEnumerator ProcessCoolDown()
    {
        float elapseTime = 0f;
        while (true)
        {
            elapseTime += Time.deltaTime;

            if (_isSummoned)
            {
                elapseTime = 0f;
                _isSummoned = false;
                canSummon = false;
            }
            if (elapseTime - statsManager.currentStatSO.GetStatValue(Stat.CoolDownTime) >= 0f)
            {
                canSummon = true;
            }
            else
            {
                canSummon = false;
            }
            yield return null;
        }
    }

    /// <summary>
    /// Phương thức triệu hồi khiên xuay tròn xung quanh
    /// </summary>
    [ContextMenu("Summon Orbit Shields")]
    public void SummonOrbitShields()
    {
        _isSummoned = true;
        float summonQuantity = statsManager.currentStatSO.GetStatValue(Stat.ProjectileQuantity) + statsManager.currentStatSO.GetStatValue(Stat.ProjectileQuantity);
        for (int i = 0; i < summonQuantity; i++)
        {
            float angle = i * 360f / summonQuantity;
            float rad = angle * Mathf.Deg2Rad;

            Vector3 offset = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f) * summonRadius;
            Vector3 spawnPos = transform.position + offset;

            tempOrbitShieldGO = orbitShieldPool.GoOutPool(orbitShieldPool.transform);
            tempOrbitShieldGO.transform.position = spawnPos;


            //GameObject shield = Instantiate(orbitShieldPool.pooledGO, spawnPos, Quaternion.identity);
            //shield.transform.SetParent(transform);
            //shield.transform.rotation = Quaternion.identity;
        }
    }

}
