namespace DotPlatform.Domain.Uow
{
    /// <summary>
    /// 表示实现此接口的类为工作单元
    /// </summary>
    public interface IUnitOfWork : IActiveUnitOfWork, IUnitOfWorkCompleteHandle
    {
        void Begin(UnitOfWorkOptions options);
    }
}
