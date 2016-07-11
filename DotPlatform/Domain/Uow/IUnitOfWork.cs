namespace DotPlatform.Domain.Uow
{
    /// <summary>
    /// 表示实现此接口的类为工作单元
    /// </summary>
    public interface IUnitOfWork : IActiveUnitOfWork, IUnitOfWorkCompleteHandle
    {
        /// <summary>
        /// 开始工作单元
        /// </summary>
        /// <param name="options">工作单元参数选项</param>
        void Begin(UnitOfWorkOptions options);
    }
}
