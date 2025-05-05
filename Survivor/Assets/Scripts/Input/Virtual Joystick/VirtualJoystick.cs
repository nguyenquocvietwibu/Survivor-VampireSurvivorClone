using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using System.Collections;

public class VirtualJoystick : MonoBehaviour,
    IDragHandler,
    IPointerDownHandler,
    IPointerUpHandler,
    ISubstituteObject<VirtualJoystick>
{
    public static VirtualJoystick instance;

    public RectTransform joyStickBacgroundRectTransform;
    public RectTransform joystickHandleRectTransform;

    public RectTransform joyStickAreaRectTransform;

    public Canvas joystickCanvas; // Canvas chứa joystick
   
    public Camera joystickCanvascanvasCamera; // Render Camera của Canvas (cần khi render mode là ScreenSpace-Camera và Worldspace)
    public float x;
    public float y;
    public Vector2 vector2;
    public Vector2 localPointDragVector2;
    public Vector2 clampedVector2;
    public Vector2 AnchoredVector2;
    public Vector2 screenPointUpPositionVector2;
    public Vector2 screenPointDownPositionVector2;
    public Vector2 screenPointDragPositionVector2;
    public Vector3 vector3;
    public Vector3 worldPointDownPositionVector3;
    public Vector3 worldPointUpPositionVector3;
    public Vector3 worldPointDragPositionVector3;

    public bool isJoystickMove;
    public bool isJoystickUp;
    /// <summary>
    /// Bán kinh di chuyển của cần điều khiển joystick
    /// </summary>
    public float joyStickRadius;
    [Header("Input joyStick vector2 runtime")]
    public Vector2 joystickVector2;

    public Vector2 testVector2;

    public Coroutine joystickUpCoroutine;

    private void Awake()
    {
        PerformSubstitute(this);
        
        Debug.Log("Awake Virtual Joystick");
    }
    private void Start()
    {

        joystickCanvas = GetComponentInParent<Canvas>();
        joyStickAreaRectTransform = GetComponentInParent<RectTransform>();
        RectTransform joystickCanvasRectTransform = joystickCanvas.transform as RectTransform;

        x = joystickCanvasRectTransform.rect.x;
        y = joystickCanvasRectTransform.rect.y;

        if (joystickCanvascanvasCamera == null)
        {
            joystickCanvascanvasCamera = Camera.main;
        }
        

        float joystickBackfroundWidth = joyStickBacgroundRectTransform.rect.width;
        float joystickBackfroundHeight = joyStickBacgroundRectTransform.rect.height;

        joyStickRadius = (joystickBackfroundWidth + joystickBackfroundHeight) / 4;

        HideJoyStick();

    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drag");
        // Chuyển đổi tọa độ màn hình sang tọa độ local trong background của joystick
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joyStickBacgroundRectTransform, eventData.position, (joystickCanvas.renderMode == RenderMode.WorldSpace || joystickCanvas.renderMode == RenderMode.ScreenSpaceCamera) ? joystickCanvascanvasCamera : null, out localPointDragVector2))
        {
            // Giới hạn trong phạm vi bán kính
            clampedVector2 = Vector2.ClampMagnitude(localPointDragVector2, joyStickRadius);
            AnchoredVector2 = joystickHandleRectTransform.anchoredPosition;
            // Di chuyển cần joystick
            joystickHandleRectTransform.anchoredPosition = clampedVector2;

            // Lưu hướng di chuyển (normalized) và độ lớn (tùy bạn muốn dùng)
            joystickVector2 = clampedVector2 / joyStickRadius;

            //Debug.Log($"[Joystick] Drag vector: {joystickVector2}");
            testVector2 = localPointDragVector2;
        }
        isJoystickMove = true;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("[Joystick] OnPointerDown: " + eventData.position);

        // ScreenPointToWorldPointInRectangle sẽ chuyển đổi tọa độ Vector2 của eventdata dưới dạng tọa độ màn hình thành tọa độ Vector3 của evendata dưới dạng tọa độ thế giới và cần 1 biến out kiểu vector3 để lưu trữ kết quả 
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(joystickCanvas.transform as RectTransform, eventData.position, (joystickCanvas.renderMode == RenderMode.WorldSpace || joystickCanvas.renderMode == RenderMode.ScreenSpaceCamera) ? joystickCanvascanvasCamera : null, out worldPointDownPositionVector3))
        {
            joyStickBacgroundRectTransform.position = worldPointDownPositionVector3;
            joystickHandleRectTransform.anchoredPosition = Vector2.zero;
            screenPointDownPositionVector2 = eventData.position;
        }
        ShowJoyStick();

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("[Joystick] OnPointerUp: " + eventData.position);
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(joystickCanvas.transform as RectTransform, eventData.position, (joystickCanvas.renderMode == RenderMode.WorldSpace || joystickCanvas.renderMode == RenderMode.ScreenSpaceCamera) ? joystickCanvascanvasCamera : null, out worldPointUpPositionVector3))
        {
            joyStickBacgroundRectTransform.position = worldPointDownPositionVector3;
            joystickHandleRectTransform.anchoredPosition = Vector2.zero;
            screenPointDownPositionVector2 = eventData.position;
        }
        HideJoyStick();
        joystickVector2 = Vector2.zero;
        isJoystickMove = false;
        if (joystickUpCoroutine != null)
        {
            StopCoroutine(joystickUpCoroutine);
            joystickUpCoroutine = StartCoroutine(ProcessJoystickUpCancel());
        }
        else
        {
            joystickUpCoroutine = StartCoroutine(ProcessJoystickUpCancel());
        }
    }

    public void ShowJoyStick()
    {
        joyStickBacgroundRectTransform.gameObject.SetActive(true);
    }
    public void HideJoyStick()
    {
        joyStickBacgroundRectTransform.gameObject.SetActive(false);
    }

    public void PerformSubstitute(VirtualJoystick executedInstance)
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
            instance = this;
        }
    }

    public IEnumerator ProcessJoystickUpCancel()
    {
        isJoystickUp = true;
        yield return new WaitForEndOfFrame();
        isJoystickUp = false;
    }
}