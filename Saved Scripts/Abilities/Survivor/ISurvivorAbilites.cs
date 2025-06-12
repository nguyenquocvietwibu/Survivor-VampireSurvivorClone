using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISurvivorBaseAbilites : IReceiveAbilitiesAble<Survivor>, IMoveAble, IDamageAble, IDieAble, IReviveAble
{
    public Survivor survivor { get;}
}
