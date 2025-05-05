using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatDebuff : MonoBehaviour
{
    // Start is called before the first frame update

    public StatsManager statsManager;

    private bool _hasStarted;

    private void OnEnable()
    {
        if (_hasStarted)
        {

        }
    }

    void Start()
    {
        _hasStarted = true;
        GetComponentInParent<StatsManager>();
    }

}
