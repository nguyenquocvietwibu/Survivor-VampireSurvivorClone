using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Lớp tiện ích nhà máy game object cho phép tạo ra các game object
/// </summary>
public static class GameObjectFactory
{
    public static GameObject CreateProduct(GameObject gameObjectProduct, Transform parentTransform)
    {
        return GameObject.Instantiate(gameObjectProduct, parentTransform);
    }
    public static GameObject CreateProduct(GameObject gameObjectProduct)
    {
        return GameObject.Instantiate(gameObjectProduct);
    }
}
