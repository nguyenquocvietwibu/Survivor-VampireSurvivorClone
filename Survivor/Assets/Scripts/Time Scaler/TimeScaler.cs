using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaler : MonoBehaviour
{
    private static TimeScaler _instance;

    public float timeScale;

    public int timeScalerGOAmount = 0;
    public static TimeScaler Instance { get => _instance; set => _instance = value; }

    private void Awake()
    {
        timeScalerGOAmount = FindObjectsOfType(typeof(TimeScaler)).Length;
        if (timeScalerGOAmount > 1)
        {
            throw new System.Exception("More than 1 TimeScalerGO");
        }
        _instance = this;
    }

    private void Start()
    {
        timeScale = 1f;
    }

    public void Update()
    {
        Time.timeScale = timeScale;
    }
}
