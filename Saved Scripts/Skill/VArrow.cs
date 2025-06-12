using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VArrow : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer spriteRenderer;

    private Color _originColor;
    private float _disappearSpeed;
    private float _growthSpeed;
    private float _maxSize;
    private bool _hasStarted;

    private void OnEnable()
    {

        if (_hasStarted)
        {
            transform.localScale = Vector3.zero;

        }
    }

    private void OnDisable()
    {
        if (_hasStarted)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _originColor = spriteRenderer.color;
        _disappearSpeed = 2f;
        _growthSpeed = 20f;
        _maxSize = 4f;
    }
    void Start()
    {
        _hasStarted = true;
        transform.localScale = Vector3.zero;
        spriteRenderer.color = _originColor;
    }

    // Update is called once per frame
    void Update()
    {
        float scale = transform.localScale.x + _growthSpeed * Time.deltaTime;
        scale = Mathf.Clamp(scale, 0f, _maxSize);
        transform.localScale = new Vector3(scale, scale, 0f);
        if (transform.localScale.x >= _maxSize)
        {
            Color opacityColor = spriteRenderer.color;
            float opacity = opacityColor.a - _disappearSpeed * Time.deltaTime;
            opacity = Mathf.Clamp(opacity, 0f, 1f);
            opacityColor.a = opacity;
            spriteRenderer.color = opacityColor;
            if (spriteRenderer.color.a <= 0f)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
