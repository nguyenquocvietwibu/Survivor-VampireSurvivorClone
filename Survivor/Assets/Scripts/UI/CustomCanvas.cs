using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private CanvasScaler _customCanvasScaler;
    [SerializeField] private Canvas _customCanvas;

    private void Awake()
    {
        if (_customCanvas == null)
        {
            _customCanvas = GetComponent<Canvas>();
            if (_customCanvas == null)
            {
                throw new System.Exception("custom cavas is null");
            }
            else
            {
                if (_customCanvas.worldCamera == null)
                {
                    _customCanvas.worldCamera = Camera.main;
                }
            }
        }


        if (_customCanvasScaler == null)
        {
            _customCanvasScaler = GetComponent<CanvasScaler>();
            if (_customCanvasScaler == null)
            {
                throw new System.Exception("cusom canvas scaler is null");
            }
            else
            {
                if (Screen.width > Screen.height)
                {
                    _customCanvasScaler.referenceResolution = new Vector2(1920, 1080);
                }
                else if (Screen.width < Screen.height)
                {
                    _customCanvasScaler.referenceResolution = new Vector2(1080, 1920);
                }
                _customCanvasScaler.referencePixelsPerUnit = _customCanvasScaler.referenceResolution.y / (Camera.main.orthographicSize * 2);
            }
        }
    }
    //void Start()
    //{
        
    //}
}
