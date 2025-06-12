using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SurvivorAnimationHash
{
    public static int moveHash = Animator.StringToHash("Survivor Move");
    public static int idleHash = Animator.StringToHash("Survivor Idle");
    public static int disappearHash = Animator.StringToHash("Survivor Disappear");
}
