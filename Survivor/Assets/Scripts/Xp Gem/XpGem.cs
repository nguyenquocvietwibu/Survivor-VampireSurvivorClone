using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpGem : MonoBehaviour
{
    public GameObjectPool XpGemPool;
    
    public CapsuleCollider2D capsuleCollider2D;

    public StatsManager statsManager;
    private void Awake()
    {
        XpGemPool = GetComponentInParent<GameObjectPool>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        statsManager = GetComponent<StatsManager>();
        statsManager.CloneStats();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SurvivorPickupArea"))
        {
            Debug.Log($"{gameObject.name} is picked by {Survivor.instance.gameObject.name}");
            Survivor.instance.basicAbilitiesSO.GainXp(statsManager.currentStatSO.GetStatValue(Stat.Experience));
            XpGemPool.GoInPool(gameObject);
        }
    }
}
