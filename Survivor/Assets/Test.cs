using UnityEngine;

public class TestContextMenu : MonoBehaviour
{
    public int counter = 0;

    [ContextMenu("Reset Counter")]
    private void ResetCounter()
    {
        counter = 0;
        Debug.Log("Counter reset!");
    }
}
