using UnityEngine;
using UnityEngine.Events;

public interface ILevelUpAbility
{
    public event UnityAction LevelUpPerformed;

    //public static readonly int[] xpToNextLevel = new int[]
    //{
    //    100, 200, 350, 500, /*...*/ 99999 // Đến level 100
    //};
    //public int GetXpToNextLevel(int currentlevel)
    //{
    //    return xpToNextLevel[currentlevel - 1]; // hoặc gọi công thức
    //}

    public void LevelUp();

    /// <summary>
    /// Tăng số kinh nghiệm cần thiết cho cấp hiện tại so với cấp trước theo số mũ là số cấp
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    //public static int GetXpRequireForLevel(int level)
    //{
    //    return Mathf.FloorToInt(100 * Mathf.Pow(1.1f, level)); // tăng dần mỗi cấp theo số mũ
    //}

    /// <summary>
    /// Tăng tuyến tính mỗi cấp cần hơn cấp trước 50 XP
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public static int GetXpRequired(int level)
    {
         return 100 + (level) * 50; 
    }

    public void GainXp(int xpAmount);

}
