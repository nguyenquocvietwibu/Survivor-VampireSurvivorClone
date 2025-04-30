using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Survivor Unity Events SO", menuName = "Scriptable Objects/Unity Event/Survivor")]
public class SurvivorUnityEventsSO : ScriptableObject
{
    public UnityEvent MoveEventTrigger;
    public UnityEvent StandEventTrigger;
    public UnityEvent DieEventTrigger;
    public UnityEvent DisappearEventTrigger;
    public UnityEvent LevelUpEventTrigger;
}