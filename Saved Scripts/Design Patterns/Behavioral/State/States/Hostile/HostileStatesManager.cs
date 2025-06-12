using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileStatesManager : MonoBehaviour
{
    public HostileMoveState moveState;
    public HostileHitState hitBackState;
    public HostileDisappearState disappearState;
    public void ReceiveState(Hostile hostile)
    {
        moveState = new(hostile);
        hitBackState = new(hostile);
        disappearState = new(hostile);
    }
}
