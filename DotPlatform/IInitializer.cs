namespace DotPlatform
{
    /// <summary>
    /// 表示实现此接口的类，会在对象初始化后自动调用 <see cref="Initialize"/> 方法，在使用之前
    /// </summary>
    public interface IInitializer
    {
        /// <summary>
        /// 初始化操作
        /// </summary>
        void Initialize();
    }
}
