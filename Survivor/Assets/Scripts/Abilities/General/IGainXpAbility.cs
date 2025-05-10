using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGainXpAbility
{
    /// <summary>
    /// Tăng tuyến tính mỗi cấp cần hơn cấp trước 5 Xp, ít nhất cần 10 xp để lên cấp độ đầu tiên
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public static float GetXpRequired(float level)
    {
        return 10 + (level) * 5;
    }

    public void GainXp(float xpAmount);
}
