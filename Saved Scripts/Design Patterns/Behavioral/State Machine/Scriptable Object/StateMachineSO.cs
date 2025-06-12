using UnityEngine;

[CreateAssetMenu(fileName = "New State Machine SO", menuName = "Scriptable Objects/State Machine")]
public class StateMachineSO : ScriptableObject, ICloneScriptableObjectAbility<StateMachineSO>
{

#if UNITY_EDITOR
    public string currrenStateName;
#endif

    public StateBehavior currentStateBehavior;

    public void InitializeState(StateBehavior stateBehaviorInitial)
    {
        if (currentStateBehavior == null)
        {
            currentStateBehavior = stateBehaviorInitial;
            currentStateBehavior.EnterState();
        }

#if UNITY_EDITOR
        currrenStateName = currentStateBehavior.ToString();
#endif
    }

    public void UpdateState()
    {
        if (currentStateBehavior != null)
        {
            currentStateBehavior.UpdateState();
#if UNITY_EDITOR
            currrenStateName = currentStateBehavior.ToString();
#endif
        }
        else
        {
            Debug.Log("Không có state nào để cập nhật");
        }
    }

    public void SwitchState(StateBehavior stateBehaviorSwitch)
    {
        if (currentStateBehavior != null)
        {
            if (currentStateBehavior != stateBehaviorSwitch)
            {
                currentStateBehavior.ExitState();
                currentStateBehavior = stateBehaviorSwitch;
                currentStateBehavior.EnterState();
#if UNITY_EDITOR
                currrenStateName = currentStateBehavior.stateName;
#endif
            }
        }
        else
        {
            Debug.Log("Chưa có state khởi tạo");
        }
    }

    public StateMachineSO GetCloneSO()
    {
        StateMachineSO cloneStateMachineSO = ScriptableObject.CreateInstance<StateMachineSO>();
        cloneStateMachineSO.currentStateBehavior = null;
        return cloneStateMachineSO;
    }
}
