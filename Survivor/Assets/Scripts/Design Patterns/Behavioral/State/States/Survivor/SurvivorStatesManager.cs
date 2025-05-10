using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorStatesManager : MonoBehaviour
{
    public SurvivorIdleState idleState;
    public SurvivorMoveState moveState;

    public void ReceiveStates(Survivor receivedSurvivor)
    {
        idleState = new (receivedSurvivor);
        moveState = new (receivedSurvivor);
    }
}
