using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInvincibleAbility
{
    public IEnumerator ProcessTemporaryInivicibility(float invicibilityTime);
}
