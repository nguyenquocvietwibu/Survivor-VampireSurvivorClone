using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Lớp khe nứt triệu hồi của khu rừng điên sẽ thực hiện triệu hồi liên tục các thù địch theo một chu kì nhất địnhg
/// </summary>
public class HostileSummonRift : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject weakHostilePrefabs;
    public GameObject moderateHostilePrefabs;
    public GameObject strongHostilePrefabs;
    public GameObject eliteHostilePrefabs;
    public GameObject legendHostilePrefabs;

    public Coroutine SpawnCoroutine;

    public GameObjectPool weakHostilePool;
    public GameObjectPool moderateHostilePool;
    public GameObjectPool strongHostilePool;
    public GameObjectPool eliteHostilePool;
    public GameObjectPool legendHostilePool;

    public GameObject trackedSurvivorGO;

    public RectTransform canvasRectTransform;

    public Vector3 worldPointVector3;

    public GameObject summonedHostileGO;

    public GameObject tempHostileGO;

    public CanvasScaler trackedCanvasScaler;


    public int yCellScreen;
    public int xCellScreen;

    void Start()
    {

        if (trackedCanvasScaler == null)
        {
            throw new System.Exception("trackedCanvasScaler is null");
        }
        else
        {

            yCellScreen = Mathf.RoundToInt(Camera.main.orthographicSize * 2f - Mathf.Abs(Camera.main.orthographicSize * 2f - Screen.height * Camera.main.orthographicSize * 2f / trackedCanvasScaler.referenceResolution.y));
            xCellScreen = Mathf.CeilToInt(trackedCanvasScaler.referenceResolution.x * yCellScreen / trackedCanvasScaler.referenceResolution.y - Mathf.Abs(Screen.width * yCellScreen / trackedCanvasScaler.referenceResolution.y - trackedCanvasScaler.referenceResolution.x * yCellScreen / trackedCanvasScaler.referenceResolution.y));
        }
        if (trackedSurvivorGO == null)
        {
            trackedSurvivorGO = Survivor.instance.gameObject;
            if (trackedSurvivorGO == null)
            {
                throw new System.Exception("tracked survivor game object is null");
            }
        }

        GameObjectPool[] gameObjectPoolArray = GetComponentsInChildren<GameObjectPool>();

        foreach (GameObjectPool gameObjectPool in gameObjectPoolArray)
        {
            switch (gameObjectPool.tag)
            {
                case "WeakHostilePool":
                    weakHostilePool = gameObjectPool;
                    weakHostilePool.pooledGO = weakHostilePrefabs;
                    weakHostilePool.PreWarm(20, weakHostilePool.transform);
                    break;
                case "ModerateHostilePool":
                    moderateHostilePool = gameObjectPool;
                    moderateHostilePool.pooledGO = moderateHostilePrefabs;
                    moderateHostilePool.PreWarm(20, moderateHostilePool.transform);
                    break;
                case "StrongHostilePool":
                    strongHostilePool = gameObjectPool;
                    strongHostilePool.pooledGO = strongHostilePrefabs;
                    strongHostilePool.PreWarm(20, strongHostilePool.transform);
                    break;
                case "EliteHostilePool":
                    eliteHostilePool = gameObjectPool;
                    eliteHostilePool.pooledGO = eliteHostilePrefabs;
                    eliteHostilePool.PreWarm(20, eliteHostilePool.transform);
                    break;

            }
        }

        SpawnCoroutine = StartCoroutine(SpawnHostileEveryTime(1f));


    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    /// <summary>
    /// Coroutine thực hiện sinh ra các thù địch mỗi giây (là tham số time) 
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    IEnumerator SpawnHostileEveryTime(float time)
    {
        // Vòng lặp vô tận
        while (true)
        {
            SpawnHostileRandomAroundScreen();
            yield return new WaitForSeconds(time);
        }
    }

    /// <summary>
    /// Sinh ra các thù địch ngẫu nhiên sát bên ngoài trên, dưới, trái, phải theo màn hình hiện tại
    /// Thời gian chơi càng lâu thì thù địch cấp cao sẽ dần được sản sinh
    /// </summary>
    public void SpawnHostileRandomAroundScreen()
    {
        Debug.Log(Random.Range(0, 2));

        //Sinh ra thù địch tại ví trí mặc định và set parent transform

        if (Time.time >= 10f)
        {
            if (Time.time >= 20f)
            {
                if (Time.time >= 30f)
                {
                    if (Random.Range(0, 2) > 0)
                    {
                        tempHostileGO = eliteHostilePool.GoOutPool(eliteHostilePool.transform);
                    }
                    else
                    {
                        tempHostileGO = strongHostilePool.GoOutPool(strongHostilePool.transform);
                    }

                }
                else
                {
                    if (Random.Range(0, 2) > 0)
                    {
                        tempHostileGO = strongHostilePool.GoOutPool(strongHostilePool.transform);
                    }
                    else
                    {
                        tempHostileGO = moderateHostilePool.GoOutPool(moderateHostilePool.transform);
                    }
                }

            }
            else
            {
                if (Random.Range(0, 2) > 0)
                {
                    tempHostileGO = moderateHostilePool.GoOutPool(moderateHostilePool.transform);
                }
                else
                {
                    tempHostileGO = weakHostilePool.GoOutPool(weakHostilePool.transform);
                }
            }
        }
        else
        {
            tempHostileGO = weakHostilePool.GoOutPool(weakHostilePool.transform);
        }

        // kiểm tra ngẫu nhiên nếu lớn hơn 0 tiếp tục kiểm tra ngẫu nhiên nếu lớn hơn 0 thì thực hiện sinh ra
        if (Random.Range(0, 2) > 0)
        {
            if (Random.Range(0, 2) > 0)
            {
                tempHostileGO.transform.position = new Vector3(trackedSurvivorGO.transform.position.x - xCellScreen / 2f - 1, Random.Range(trackedSurvivorGO.transform.position.y - yCellScreen / 2f, trackedSurvivorGO.transform.position.y + yCellScreen / 2f));
            }
            else
            {
                tempHostileGO.transform.position = new Vector3(trackedSurvivorGO.transform.position.x + xCellScreen / 2f + 1, Random.Range(trackedSurvivorGO.transform.position.y - yCellScreen / 2f, trackedSurvivorGO.transform.position.y + yCellScreen / 2f));
            }
        }

        //
        else
        {
            if (Random.Range(0, 2) > 0)
            {
                tempHostileGO.transform.position = new Vector3(Random.Range(trackedSurvivorGO.transform.position.x - xCellScreen / 2f, trackedSurvivorGO.transform.position.x + xCellScreen / 2f), trackedSurvivorGO.transform.position.y - yCellScreen / 2f - 1);
            }
            else
            {
                tempHostileGO.transform.position = new Vector3(Random.Range(trackedSurvivorGO.transform.position.x - xCellScreen / 2f, trackedSurvivorGO.transform.position.x + xCellScreen / 2f), trackedSurvivorGO.transform.position.y + yCellScreen / 2f + 1);
            }
        }

    }

    public GameObject MakeBuffedHostile(GameObject buffedHostile)
    {
        buffedHostile.transform.localScale = Vector3.one * 1.5f;
        return buffedHostile;
    }
}
