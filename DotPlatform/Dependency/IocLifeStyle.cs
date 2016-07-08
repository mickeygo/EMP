namespace DotPlatform.Dependency
{
    /// <summary>
    /// IOC 容器中注册对象的生命周期
    /// </summary>
    public enum IocLifeStyle
    {
        /// <summary>
        /// 单例模式，每次解析返回的都是同一个实例，
        /// </summary>
        Singleton,

        /// <summary>
        /// 瞬时的，每次解析时都会创建一个新的对象
        /// </summary>
        Transient
    }
}
