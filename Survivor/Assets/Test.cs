using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    private void OnEnable()
    {
        Debug.Log("Enable Test");
        Debug.Log(VirtualJoystick.instance);
        Debug.Log(Survivor.instance);
    }
}
