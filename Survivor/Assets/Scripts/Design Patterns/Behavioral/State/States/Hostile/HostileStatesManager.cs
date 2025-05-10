using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileStatesManager : MonoBehaviour
{
    public HostileMoveState moveState;
    public HostileImmobileState immobileState;

    public void ReceiveState(Hostile hostile)
    {
        moveState = new(hostile);
        immobileState = new(hostile);
    }
}
