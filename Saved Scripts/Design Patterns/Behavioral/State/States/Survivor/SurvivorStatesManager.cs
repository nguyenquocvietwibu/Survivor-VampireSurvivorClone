using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorStatesManager : MonoBehaviour
{
    private SurvivorIdleState _idleState;
    private SurvivorMoveState _moveState;

    public SurvivorIdleState idleState => _idleState;
    public SurvivorMoveState moveState => _moveState;

    public void ReceiveStates(Survivor receivedSurvivor)
    {
        _idleState = new (receivedSurvivor);
        _moveState = new (receivedSurvivor);
    }
}
