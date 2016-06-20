namespace DotPlatform.Domain.Uow
{
    /// <summary>
    /// 表示实现此接口的类用于提供当前的工作单元
    /// </summary>
    public interface ICurrentUnitOfWorkProvider
    {
        /// <summary>
        /// 获取或设置当前的工作单元
        /// </summary>
        IUnitOfWork Current { get; set; }
    }
}
