using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Virtual Joystick Unity Events SO", menuName = "Scriptable Objects/Unity Event/Virtual Joystick")]
public class VirtualJoystickUnityEventsSO : ScriptableObject
{
    public UnityEvent MoveEventTrigger;
    public UnityEvent IdleEventTrigger;
}
