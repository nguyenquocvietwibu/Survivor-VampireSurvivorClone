﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorSelecter : MonoBehaviour
{
    public GameObject selectedSurvivorPrefab;
    public SpriteRenderer spriteRenderer;
    private void Awake()
    {
        Destroy(GetComponent<SpriteRenderer>());
        if (selectedSurvivorPrefab == null)
        {
            throw new System.Exception("NULL");
        }
        else
        {
            if (selectedSurvivorPrefab.GetComponent<Survivor>() != null)
            {
                GameObject tempSelectedSurvivorGO = GameObjectFactory.CreateProduct(selectedSurvivorPrefab, transform.parent);
                tempSelectedSurvivorGO.transform.position = Vector3.zero;
            }
            else
            {
                throw new System.Exception("NOT TRUE");
            }
        }

    }
    private void OnValidate()
    {
        TryGetComponent(out spriteRenderer); //Unity nhìn vào kiểu (SpriteRenderer) của spriteRenderer để biết cần tìm loại component nào.
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = selectedSurvivorPrefab.GetComponent<SpriteRenderer>().sprite;
        }
    }
}
