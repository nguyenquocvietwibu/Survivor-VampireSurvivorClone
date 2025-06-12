using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Lớp thực hiện hiệu ứng cuộn vô tận tilemap quanh đối tượng được theo dõi
/// </summary>
public class InfinityScrollTilemapAroundSurvivor : MonoBehaviour, IActionsObserver
{
    public Tilemap scrolledTilemap;

    public GameObject scrolledTilemapGO;
    public GameObject firstScrolledTilemapGO;
    public GameObject secondScrolledTilemapGO;
    public GameObject thirdScrolledTilemapGO;
    public GameObject lastScrolledTilemapGO;

    public Survivor trackedSurvivor;

    public BoundsInt scrolledTilmapCellsBound;

    public int xScrolledTileMapCells;
    public int yScrolledTileMapCells;

    public Vector3 checkLocalPositionVector3;

    private GameObject _tempScrolledTilemapGO;

    public float distance;
    public float scrolledDistance;

    private bool _hasStarted;


    public void SubscribeActions()
    {
        if (_hasStarted)
        {
            //trackedSurvivor.basicAbilitiesSO.MovePerformed += OnSurvivorMove;
        }
    }

    public void UnSubscribeActions()
    {
        if (_hasStarted)
        {
            //trackedSurvivor.basicAbilitiesSO.MovePerformed -= OnSurvivorMove;
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

    void Start()
    {
        _hasStarted = true;
        if (scrolledTilemap == null)
        {
            scrolledTilemap = GetComponentInChildren<Tilemap>();
            Debug.Log(scrolledTilemap);
            if (scrolledTilemap == null)
            {
                throw new System.Exception("Scroll map is null");
            }
            else
            {
                scrolledTilemapGO = scrolledTilemap.gameObject;

                scrolledTilmapCellsBound = scrolledTilemap.cellBounds;

                xScrolledTileMapCells = -scrolledTilmapCellsBound.x;
                yScrolledTileMapCells = -scrolledTilmapCellsBound.y;

                firstScrolledTilemapGO = scrolledTilemapGO;

                secondScrolledTilemapGO = Instantiate(scrolledTilemapGO, transform);
                secondScrolledTilemapGO.transform.position = firstScrolledTilemapGO.transform.position - new Vector3(0, yScrolledTileMapCells * 2, 0);

                thirdScrolledTilemapGO = Instantiate(scrolledTilemapGO, transform);
                thirdScrolledTilemapGO.transform.position = secondScrolledTilemapGO.transform.position + new Vector3(xScrolledTileMapCells * 2, 0, 0);

                lastScrolledTilemapGO = Instantiate(scrolledTilemapGO, transform);
                lastScrolledTilemapGO.transform.position = firstScrolledTilemapGO.transform.position + new Vector3(xScrolledTileMapCells * 2, 0, 0);
            }
        }
        else
        {
            scrolledTilemapGO = scrolledTilemap.gameObject;

            scrolledTilmapCellsBound = scrolledTilemap.cellBounds;

            xScrolledTileMapCells = -scrolledTilmapCellsBound.x;
            yScrolledTileMapCells = -scrolledTilmapCellsBound.y;

            firstScrolledTilemapGO = scrolledTilemapGO;

            secondScrolledTilemapGO = Instantiate(scrolledTilemapGO, transform);
            secondScrolledTilemapGO.transform.position = firstScrolledTilemapGO.transform.position - new Vector3(0, yScrolledTileMapCells * 2, 0);

            thirdScrolledTilemapGO = Instantiate(scrolledTilemapGO, transform);
            thirdScrolledTilemapGO.transform.position = secondScrolledTilemapGO.transform.position + new Vector3(xScrolledTileMapCells * 2, 0, 0);

            lastScrolledTilemapGO = Instantiate(scrolledTilemapGO, transform);
            lastScrolledTilemapGO.transform.position = firstScrolledTilemapGO.transform.position + new Vector3(xScrolledTileMapCells * 2, 0, 0);
        }
        //trackedSurvivor = Survivor.instance;
        if (trackedSurvivor == null)
        {
            throw new System.Exception("NULL");
        }
        SubscribeActions();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    //ScrollTilemap();
    //}

    public void SwapFistAndLastScrollTilemapGO()
    {
        _tempScrolledTilemapGO = firstScrolledTilemapGO;
        firstScrolledTilemapGO = lastScrolledTilemapGO;
        lastScrolledTilemapGO = _tempScrolledTilemapGO;
    }

    public void OnSurvivorMove()
    {
        ScrollTilemap();
    }

    public void ScrollTilemap()
    {
        if (trackedSurvivor.transform.position.x <= firstScrolledTilemapGO.transform.position.x - xScrolledTileMapCells / 2f)
        {
            if (trackedSurvivor.transform.position.y >= firstScrolledTilemapGO.transform.position.y)
            {
                if (secondScrolledTilemapGO.transform.position != firstScrolledTilemapGO.transform.position + new Vector3(0, yScrolledTileMapCells * 2, 0) - new Vector3(xScrolledTileMapCells * 2, 0, 0))
                {
                    secondScrolledTilemapGO.transform.position = firstScrolledTilemapGO.transform.position + new Vector3(0, yScrolledTileMapCells * 2, 0) - new Vector3(xScrolledTileMapCells * 2, 0, 0);
                }
                if (thirdScrolledTilemapGO.transform.position != secondScrolledTilemapGO.transform.position + new Vector3(xScrolledTileMapCells * 2, 0, 0))
                {
                    thirdScrolledTilemapGO.transform.position = secondScrolledTilemapGO.transform.position + new Vector3(xScrolledTileMapCells * 2, 0, 0);
                }

            }
            else if (trackedSurvivor.transform.position.y <= firstScrolledTilemapGO.transform.position.y)
            {
                if (secondScrolledTilemapGO.transform.position != firstScrolledTilemapGO.transform.position - new Vector3(0, yScrolledTileMapCells * 2, 0) - new Vector3(xScrolledTileMapCells * 2, 0, 0))
                {
                    secondScrolledTilemapGO.transform.position = firstScrolledTilemapGO.transform.position - new Vector3(0, yScrolledTileMapCells * 2, 0) - new Vector3(xScrolledTileMapCells * 2, 0, 0);
                }
                if (thirdScrolledTilemapGO.transform.position != secondScrolledTilemapGO.transform.position + new Vector3(xScrolledTileMapCells * 2, 0, 0))
                {
                    thirdScrolledTilemapGO.transform.position = secondScrolledTilemapGO.transform.position + new Vector3(xScrolledTileMapCells * 2, 0, 0);
                }
            }
            if (lastScrolledTilemapGO.transform.position != firstScrolledTilemapGO.transform.position - new Vector3(xScrolledTileMapCells * 2, 0, 0))
            {
                lastScrolledTilemapGO.transform.position = firstScrolledTilemapGO.transform.position - new Vector3(xScrolledTileMapCells * 2, 0, 0);
            }

            if (trackedSurvivor.transform.position.x <= firstScrolledTilemapGO.transform.position.x - xScrolledTileMapCells)
            {
                SwapFistAndLastScrollTilemapGO();
            }

        }
        else if (trackedSurvivor.transform.position.x >= firstScrolledTilemapGO.transform.position.x + xScrolledTileMapCells / 2f)
        {
            if (trackedSurvivor.transform.position.y <= firstScrolledTilemapGO.transform.position.y)
            {
                if (secondScrolledTilemapGO.transform.position != firstScrolledTilemapGO.transform.position - new Vector3(0, yScrolledTileMapCells * 2, 0) + new Vector3(xScrolledTileMapCells * 2, 0, 0))
                {
                    secondScrolledTilemapGO.transform.position = firstScrolledTilemapGO.transform.position - new Vector3(0, yScrolledTileMapCells * 2, 0) + new Vector3(xScrolledTileMapCells * 2, 0, 0);
                }
                if (thirdScrolledTilemapGO.transform.position != secondScrolledTilemapGO.transform.position - new Vector3(xScrolledTileMapCells * 2, 0, 0))
                {
                    thirdScrolledTilemapGO.transform.position = secondScrolledTilemapGO.transform.position - new Vector3(xScrolledTileMapCells * 2, 0, 0);
                }
            }
            else if (trackedSurvivor.transform.position.y >= firstScrolledTilemapGO.transform.position.y)
            {
                if (secondScrolledTilemapGO.transform.position != firstScrolledTilemapGO.transform.position + new Vector3(0, yScrolledTileMapCells * 2, 0) + new Vector3(xScrolledTileMapCells * 2, 0, 0))
                {
                    secondScrolledTilemapGO.transform.position = firstScrolledTilemapGO.transform.position + new Vector3(0, yScrolledTileMapCells * 2, 0) + new Vector3(xScrolledTileMapCells * 2, 0, 0);

                }
                if (thirdScrolledTilemapGO.transform.position != secondScrolledTilemapGO.transform.position - new Vector3(xScrolledTileMapCells * 2, 0, 0))
                {
                    thirdScrolledTilemapGO.transform.position = secondScrolledTilemapGO.transform.position - new Vector3(xScrolledTileMapCells * 2, 0, 0);
                }
            }
            if (lastScrolledTilemapGO.transform.position != firstScrolledTilemapGO.transform.position + new Vector3(xScrolledTileMapCells * 2, 0, 0))
            {
                lastScrolledTilemapGO.transform.position = firstScrolledTilemapGO.transform.position + new Vector3(xScrolledTileMapCells * 2, 0, 0);
            }

            if (trackedSurvivor.transform.position.x >= firstScrolledTilemapGO.transform.position.x + xScrolledTileMapCells)
            {
                SwapFistAndLastScrollTilemapGO();
            }
        }
        if (trackedSurvivor.transform.position.y <= firstScrolledTilemapGO.transform.position.y - yScrolledTileMapCells / 2f)
        {
            if (trackedSurvivor.transform.position.x >= firstScrolledTilemapGO.transform.position.x)
            {
                if (secondScrolledTilemapGO.transform.position != firstScrolledTilemapGO.transform.position - new Vector3(0, yScrolledTileMapCells * 2, 0) + new Vector3(xScrolledTileMapCells * 2, 0, 0))
                {
                    secondScrolledTilemapGO.transform.position = firstScrolledTilemapGO.transform.position - new Vector3(0, yScrolledTileMapCells * 2, 0) + new Vector3(xScrolledTileMapCells * 2, 0, 0);
                }
                if (thirdScrolledTilemapGO.transform.position != secondScrolledTilemapGO.transform.position + new Vector3(0, yScrolledTileMapCells * 2, 0))
                {
                    thirdScrolledTilemapGO.transform.position = secondScrolledTilemapGO.transform.position + new Vector3(0, yScrolledTileMapCells * 2, 0);
                }
            }
            else if (trackedSurvivor.transform.position.x <= firstScrolledTilemapGO.transform.position.x)
            {
                if (secondScrolledTilemapGO.transform.position != firstScrolledTilemapGO.transform.position - new Vector3(0, yScrolledTileMapCells * 2, 0) - new Vector3(xScrolledTileMapCells * 2, 0, 0))
                {
                    secondScrolledTilemapGO.transform.position = firstScrolledTilemapGO.transform.position - new Vector3(0, yScrolledTileMapCells * 2, 0) - new Vector3(xScrolledTileMapCells * 2, 0, 0);
                }
                if (thirdScrolledTilemapGO.transform.position != secondScrolledTilemapGO.transform.position + new Vector3(0, yScrolledTileMapCells * 2, 0))
                {
                    thirdScrolledTilemapGO.transform.position = secondScrolledTilemapGO.transform.position + new Vector3(0, yScrolledTileMapCells * 2, 0);
                }
            }
            if (lastScrolledTilemapGO.transform.position != firstScrolledTilemapGO.transform.position - new Vector3(0, yScrolledTileMapCells * 2, 0))
            {
                lastScrolledTilemapGO.transform.position = firstScrolledTilemapGO.transform.position - new Vector3(0, yScrolledTileMapCells * 2, 0);
            }
            if (trackedSurvivor.transform.position.y <= firstScrolledTilemapGO.transform.position.y - yScrolledTileMapCells)
            {
                SwapFistAndLastScrollTilemapGO();
            }
        }

        else if (trackedSurvivor.transform.position.y >= firstScrolledTilemapGO.transform.position.y + yScrolledTileMapCells / 2f)
        {
            if (trackedSurvivor.transform.position.x >= firstScrolledTilemapGO.transform.position.x)
            {
                if (secondScrolledTilemapGO.transform.position != firstScrolledTilemapGO.transform.position + new Vector3(0, yScrolledTileMapCells * 2, 0) + new Vector3(xScrolledTileMapCells * 2, 0, 0))
                {
                    secondScrolledTilemapGO.transform.position = firstScrolledTilemapGO.transform.position + new Vector3(0, yScrolledTileMapCells * 2, 0) + new Vector3(xScrolledTileMapCells * 2, 0, 0);
                }
                if (thirdScrolledTilemapGO.transform.position != secondScrolledTilemapGO.transform.position - new Vector3(0, yScrolledTileMapCells * 2, 0))
                {
                    thirdScrolledTilemapGO.transform.position = secondScrolledTilemapGO.transform.position - new Vector3(0, yScrolledTileMapCells * 2, 0);
                }
            }
            else if (trackedSurvivor.transform.position.x <= firstScrolledTilemapGO.transform.position.x)
            {
                if (secondScrolledTilemapGO.transform.position != firstScrolledTilemapGO.transform.position + new Vector3(0, yScrolledTileMapCells * 2, 0) - new Vector3(xScrolledTileMapCells * 2, 0, 0))
                {
                    secondScrolledTilemapGO.transform.position = firstScrolledTilemapGO.transform.position + new Vector3(0, yScrolledTileMapCells * 2, 0) - new Vector3(xScrolledTileMapCells * 2, 0, 0);
                }
                if (thirdScrolledTilemapGO.transform.position != secondScrolledTilemapGO.transform.position - new Vector3(0, yScrolledTileMapCells * 2, 0))
                {
                    thirdScrolledTilemapGO.transform.position = secondScrolledTilemapGO.transform.position - new Vector3(0, yScrolledTileMapCells * 2, 0);
                }
            }
            if (lastScrolledTilemapGO.transform.position != firstScrolledTilemapGO.transform.position + new Vector3(0, yScrolledTileMapCells * 2, 0))
            {
                lastScrolledTilemapGO.transform.position = firstScrolledTilemapGO.transform.position + new Vector3(0, yScrolledTileMapCells * 2, 0);
            }
            if (trackedSurvivor.transform.position.y >= firstScrolledTilemapGO.transform.position.y + yScrolledTileMapCells)
            {
                SwapFistAndLastScrollTilemapGO();
            }
        }
    }

}
