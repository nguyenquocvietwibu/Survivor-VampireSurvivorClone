﻿using UnityEngine;
using UnityEngine.Events;

public interface ILevelUpAbility
{
    public event UnityAction LevelUpPerformed;

    //public static readonly float[] xpToNextLevel = new float[]
    //{
    //    100, 200, 350, 500, /*...*/ 99999 // Đến level 100
    //};
    //public float GetXpToNextLevel(float currentlevel)
    //{
    //    return xpToNextLevel[currentlevel - 1]; // hoặc gọi công thức
    //}

    public void LevelUp();

    /// <summary>
    /// Tăng số kinh nghiệm cần thiết cho cấp hiện tại so với cấp trước theo số mũ là số cấp
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    //public static float GetXpRequireForLevel(float level)
    //{
    //    return Mathf.FloorToInt(100 * Mathf.Pow(1.1f, level)); // tăng dần mỗi cấp theo số mũ
    //}



}
