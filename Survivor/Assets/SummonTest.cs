using UnityEngine;

public class ShieldTestSpawner : MonoBehaviour
{
    public GameObject shieldPrefab;
    public int shieldCount = 3;
    public float radius = 2f;

    void Start()
    {
        SummonOrbitingShields(shieldCount);
    }

    void SummonOrbitingShields(int count)
    {
        for (int i = 0; i < count; i++)
        {
            float angle = i * 360f / count;
            float rad = angle * Mathf.Deg2Rad;

            Vector3 offset = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0f) * radius;
            Vector3 spawnPos = transform.position + offset;

            GameObject shield = Instantiate(shieldPrefab, spawnPos, Quaternion.identity);
            shield.transform.SetParent(transform);
            shield.transform.rotation = Quaternion.identity;
        }
    }
}
