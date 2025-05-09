/// <summary>
/// Interface mô tả custom design pattern với ý tưởng thay thế thể hiện của T cũ thành thể hiện mới của T được tạo ra
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ISubstitute<T> where T : class
{
    /// <summary>
    /// Phương thức thực hiện việc thay thế thể hiện T cũ thành 1 thể hiện mới của T được tạo ra
    /// </summary>
    /// <param name="executeInstance"></param>
    public void PerformSubstitute(T executedInstance);
}
