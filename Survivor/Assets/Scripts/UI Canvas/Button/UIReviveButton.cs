using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIReviveButton : MonoBehaviour, ISubstituteObject<UIReviveButton>, IPointerDownHandler
{
    public static UIReviveButton instance;

    private bool _hasStarted;

    public UnityAction onClick;

    private void Awake()
    {
        PerformSubstitute(this);
        instance = this;
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
        PerformSubstitute(this);
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        onClick?.Invoke();
    }

    public void PerformSubstitute(UIReviveButton executedInstance)
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
}
