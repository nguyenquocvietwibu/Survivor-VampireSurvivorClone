using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DynamicJoysickTest : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public RectTransform joystickBG; // Nền joystick
    public RectTransform joystickHandle; // Nút joystick
    public float joystickRange = 100f; // Khoảng cách di chuyển của joystick

    private Vector2 inputVector = Vector2.zero; // Vector đầu ra để di chuyển nhân vật
    private Canvas canvas; // Canvas chứa joystick
    private Camera uiCamera; // Camera của Canvas (cần khi render mode là ScreenSpace-Camera)

    void Start()
    {
        canvas = GetComponentInParent<Canvas>(); // Lấy Canvas cha của Joystick
        uiCamera = canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera; // Nếu render mode là Overlay thì không cần camera

        joystickBG.gameObject.SetActive(false); // Ẩn joystick ban đầu
    }

    // Xử lý khi nhấn chuột vào joystick
    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform, // Canvas transform
            eventData.position, uiCamera, out pos); // Vị trí nhấn của chuột

        joystickBG.anchoredPosition = pos; // Đặt vị trí của nền joystick
        joystickHandle.anchoredPosition = Vector2.zero; // Đặt nút joystick về trung tâm
        joystickBG.gameObject.SetActive(true); // Hiển thị joystick
    }

    // Xử lý khi kéo joystick
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickBG, eventData.position, uiCamera, out pos); // Vị trí kéo chuột trong vùng joystick

        pos = Vector2.ClampMagnitude(pos, joystickRange); // Giới hạn vị trí kéo để không vượt quá phạm vi
        joystickHandle.anchoredPosition = pos; // Đặt nút joystick vào vị trí mới
        inputVector = pos / joystickRange; // Cập nhật vector đầu ra
    }

    // Xử lý khi thả chuột
    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero; // Đặt vector đầu ra về 0 khi thả chuột
        joystickHandle.anchoredPosition = Vector2.zero; // Đặt nút joystick về trung tâm
        joystickBG.gameObject.SetActive(false); // Ẩn joystick khi không sử dụng
    }

    // Các phương thức để lấy input từ joystick
    public Vector2 GetInput() => inputVector;
    public float Horizontal() => inputVector.x;
    public float Vertical() => inputVector.y;
}
