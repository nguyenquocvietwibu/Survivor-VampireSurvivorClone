using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class XpGemPoolEntry
{
    public GameObject xpGemPrefab;
    public GameObjectPool xpGemPool;
}

/// <summary>
/// Class khe triệu hồi xp gem
/// </summary>
public class XpGemSummonRift : MonoBehaviour, ISubstitute<XpGemSummonRift>
{
    public static XpGemSummonRift instance;

    public Dictionary<GameObject, GameObjectPool> xpGemPoolDict = new ();

    public List<XpGemPoolEntry> xpGemPoolEntryList = new ();

    public GameObject tempXpGemGO;
    private void Awake()
    {
        PerformSubstitute(this);
        GameObjectPool[] xpGemPoolArray = GetComponentsInChildren<GameObjectPool>();
        foreach (GameObjectPool goPool in xpGemPoolArray)
        {
            if (goPool.pooledGO.TryGetComponent<XpGem>(out XpGem xpGemKey))
            {
                if (!xpGemPoolDict.ContainsKey(xpGemKey.gameObject))
                {
                    xpGemPoolDict[xpGemKey.gameObject] = goPool;
                    xpGemPoolEntryList.Add(new() { xpGemPool = goPool, xpGemPrefab = xpGemKey.gameObject});
                    goPool.PreWarm(20, goPool.transform);
                }
                else
                {
                    Debug.Log($"Thừa prefab poolGO của {goPool.name}");
                    break;
                }
            }
        }
    }
    public void SummonXpGem(GameObject xpGemPrefab, Vector3 summonedPositionVector3)
    {
        Debug.Log("Summon Xp Gem");
        tempXpGemGO = xpGemPoolDict[xpGemPrefab].GoOutPool(xpGemPoolDict[xpGemPrefab].transform);
        tempXpGemGO.transform.position = summonedPositionVector3;
    }

    public void PerformSubstitute(XpGemSummonRift executedInstance)
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
}
