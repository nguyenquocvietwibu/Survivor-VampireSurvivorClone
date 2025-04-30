using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIReviveButton : MonoBehaviour, IPointerDownHandler
{
    public static UIReviveButton _instance;

    public UnityAction ButtonDownActionTrigger;

    public static UIReviveButton Instance { get { return _instance; } set { _instance = value; } }

    private bool _hasStarted;

    private void Awake()
    {
        _instance = this;
    }

   
    // Start is called before the first frame update
    void Start()
    {
        _hasStarted = true;
        OnEnable();
        gameObject.SetActive(false);
    }

    public void OnShowButton()
    {
        gameObject.SetActive(true);
    }
    private void OnEnable()
    {

    }

    public void OnHideButton()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {

    }


    public void OnPointerDown(PointerEventData eventData)
    {
        ButtonDownActionTrigger?.Invoke();
    }
}
