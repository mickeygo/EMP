namespace DotPlatform.Domain.Uow
{
    /// <summary>
    /// 表示实现此接口的类为工作单元
    /// </summary>
    public interface IUnitOfWork : IActiveUnitOfWork, IUnitOfWorkCompleteHandle
    {
        /// <summary>
        /// 获取工作单元的 Id.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// 获取或设置一个外部的工作单元。
        /// </summary>
        IUnitOfWork Outer { get; set; }

        /// <summary>
        /// 开始工作单元
        /// </summary>
        /// <param name="options">工作单元参数选项</param>
        void Begin(UnitOfWorkOptions options);
    }
}
