using System.Collections.Concurrent;
using System.Runtime.Remoting.Messaging;

namespace DotPlatform.Domain.Uow
{
    /// <summary>
    /// 基于 CallContext 的当前工作单元提供者。
    /// <see cref="CallContext"/> 是类似于方法调用的线程本地存储区的专用集合对象，并提供对每个逻辑执行线程都唯一的数据槽。
    /// </summary>
    public class CallContextCurrentUnitOfWorkProvider : ICurrentUnitOfWorkProvider
    {
        private const string ContextKey = ".DotPlatform.UnitOfWork.Current";

        // 缓存工作单元集合
        // Think: 如何清空字典中残留的工作单元 ...
        private static readonly ConcurrentDictionary<string, IUnitOfWork> UnitOfWorkDictionary = new ConcurrentDictionary<string, IUnitOfWork>();

        #region Private Methods

        /// <summary>
        /// 获取当前的工作单元
        /// </summary>
        private static IUnitOfWork GetCurrentUow()
        {
            // 从数据槽中取出当前线程设定的 Key 值
            var unitOfWorkKey = CallContext.LogicalGetData(ContextKey) as string;
            if (unitOfWorkKey == null)
            {
                return null;
            }

            // 尝试从字典中取出工作单元
            IUnitOfWork unitOfWork;
            if (!UnitOfWorkDictionary.TryGetValue(unitOfWorkKey, out unitOfWork))
            {
                CallContext.FreeNamedDataSlot(ContextKey);
                return null;
            }

            // 如果当前 UOW 已释放，那么就从字典集中移除该 UOW，并将 Key 从数据槽中释放
            if (unitOfWork.IsDisposed)
            {
                UnitOfWorkDictionary.TryRemove(unitOfWorkKey, out unitOfWork);
                CallContext.FreeNamedDataSlot(ContextKey);
                return null;
            }

            // 在 UOW Manager 中, 对 UOW 设置 Disposed 事件，将当前工作单元设置为 null。
            // 执行完后会调用 SetCurrentUow 并进入 ExitFromCurrentUowScope 方法中，执行 Remove 并清空 Key 资源（若没外部 Uow）.
            return unitOfWork;
        }

        private static void SetCurrentUow(IUnitOfWork value)
        {
            // 当没有设置值时（设置为 null 值），会从当前工作单元域中退出
            if (value == null)
            {
                ExitFromCurrentUowScope();
                return;
            }

            var unitOfWorkKey = CallContext.LogicalGetData(ContextKey) as string;
            if (unitOfWorkKey != null)
            {
                IUnitOfWork outer;
                if (UnitOfWorkDictionary.TryGetValue(unitOfWorkKey, out outer))
                {
                    if (outer == value)
                    {
                        return;
                    }

                    value.Outer = outer;
                }
            }

            unitOfWorkKey = value.Id;
            if (!UnitOfWorkDictionary.TryAdd(unitOfWorkKey, value))
            {
                throw new DotPlatformException("Can not set unit of work! UnitOfWorkDictionary.TryAdd returns false!");
            }

            CallContext.LogicalSetData(ContextKey, unitOfWorkKey);
        }

        /// <summary>
        /// 从当前工作单元域中退出
        /// </summary>
        private static void ExitFromCurrentUowScope()
        {
            var unitOfWorkKey = CallContext.LogicalGetData(ContextKey) as string;
            if (unitOfWorkKey == null)
            {
                return;
            }

            IUnitOfWork unitOfWork;
            if (!UnitOfWorkDictionary.TryGetValue(unitOfWorkKey, out unitOfWork))
            {
                // 上下文 Key 对应的对象不存在时，释放 Key 值并退出。
                CallContext.FreeNamedDataSlot(ContextKey);
                return;
            }

            // 从字典集合中移除 Key 对应的工作单元
            UnitOfWorkDictionary.TryRemove(unitOfWorkKey, out unitOfWork);
            if (unitOfWork.Outer == null)
            {
                CallContext.FreeNamedDataSlot(ContextKey);
                return;
            }

            // 提升外部的 UOW 到集合中
            // 检查移除的 UOW 的外部 UOW，
            //     当集合中存在此 UOW, 将该 UOW 的 Id 值设为 Key 值；
            //     不存在时，释放 Key 值并退出。
            var outerUnitOfWorkKey = unitOfWork.Outer.Id;
            if (!UnitOfWorkDictionary.TryGetValue(outerUnitOfWorkKey, out unitOfWork))
            {
                CallContext.FreeNamedDataSlot(ContextKey);
                return;
            }

            CallContext.LogicalSetData(ContextKey, outerUnitOfWorkKey);
        }

        #endregion

        public IUnitOfWork Current
        {
            get { return GetCurrentUow(); }
            set { SetCurrentUow(value); }
        }
    }
}
