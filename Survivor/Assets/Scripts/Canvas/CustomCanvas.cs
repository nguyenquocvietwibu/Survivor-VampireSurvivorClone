using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    public CanvasScaler customCanvasScaler;
    public Canvas customCanvas;

    private void Awake()
    {
        if (customCanvas == null)
        {
            customCanvas = GetComponent<Canvas>();
            if (customCanvas == null)
            {
                throw new System.Exception("custom cavas is null");
            }
            else
            {
                if (customCanvas.worldCamera == null)
                {
                    customCanvas.worldCamera = Camera.main;
                }
            }
        }


        if (customCanvasScaler == null)
        {
            customCanvasScaler = GetComponent<CanvasScaler>();
            if (customCanvasScaler == null)
            {
                throw new System.Exception("cusom canvas scaler is null");
            }
            else
            {
                if (Screen.width > Screen.height)
                {
                    customCanvasScaler.referenceResolution = new Vector2(1920, 1080);
                }
                else if (Screen.width < Screen.height)
                {
                    customCanvasScaler.referenceResolution = new Vector2(1080, 1920);
                }
                customCanvasScaler.referencePixelsPerUnit = customCanvasScaler.referenceResolution.y / (Camera.main.orthographicSize * 2);
            }
        }
    }
    //void Start()
    //{
        
    //}
}
