using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class mô tả chỉ số là 1 đối tượng
/// </summary>
[System.Serializable]
public class StatEntry
{
    /// <summary>
    /// Enum đại diện cho key của tên chỉ số
    /// </summary>
    public Stat statKey;

    /// <summary>
    /// Giá trị của chỉ số
    /// </summary>
    public float statValue;

    public bool canIncrease = true;

    public bool canDecrease = true;
}
