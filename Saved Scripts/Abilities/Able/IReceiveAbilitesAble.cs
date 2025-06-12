using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReceiveAbilitiesAble<T> where T : MonoBehaviour
{
    public void ReceiveAbilities(T receivedMonobehavior);
}
