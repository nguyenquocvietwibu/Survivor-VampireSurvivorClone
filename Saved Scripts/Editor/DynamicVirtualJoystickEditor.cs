using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(VirtualJoystick))]
public class DynamicVirtualJoystickEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Vẽ lại những trường mặc định của MonoBehaviour
        DrawDefaultInspector();

        // Lấy đối tượng DynamicVirtualJoystick đang được chọn
        VirtualJoystick dynamicVirtualJoystick = (VirtualJoystick)target;

        // Thêm nút vào Inspector
        if (GUILayout.Button("Show Joystick"))
        {
            // Gọi phương thức ShowJoyStick khi nút được nhấn
            dynamicVirtualJoystick.ShowJoyStick();
        }
        else if (GUILayout.Button("Hide Joystick"))
        {
            dynamicVirtualJoystick.HideJoyStick();
        }
    }
}
