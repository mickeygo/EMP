using System.Collections.Concurrent;
using System.Runtime.Remoting.Messaging;

namespace DotPlatform.Domain.Uow
{
    /// <summary>
    /// 基于 CallContext 的当前工作单元提供者。
    /// CallContext 是类似于方法调用的线程本地存储区的专用集合对象，并提供对每个逻辑执行线程都唯一的数据槽。
    /// </summary>
    public class CallContextCurrentUnitOfWorkProvider : ICurrentUnitOfWorkProvider
    {
        private const string ContextKey = "DotPlatform.UnitOfWork.Current";

        // 如何清空字典中残留的工作单元 ...
        // 缓存工作单元集合
        private static readonly ConcurrentDictionary<string, IUnitOfWork> UnitOfWorkDictionary = new ConcurrentDictionary<string, IUnitOfWork>();

        #region Private Methods

        /// <summary>
        /// 获取当前工作单元
        /// </summary>
        private static IUnitOfWork GetCurrentUow()
        {
            // 从数据槽中取出当前线程
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

            // 如果当前工作单元已释放，那么就从字典中移除该工作单元，并将 Key 从数据槽中释放
            if (unitOfWork.IsDisposed)
            {
                UnitOfWorkDictionary.TryRemove(unitOfWorkKey, out unitOfWork);
                CallContext.FreeNamedDataSlot(ContextKey);
                return null;
            }

            return unitOfWork;
        }

        private static void SetCurrentUow(IUnitOfWork value)
        {
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
                CallContext.FreeNamedDataSlot(ContextKey);
                return;
            }

            UnitOfWorkDictionary.TryRemove(unitOfWorkKey, out unitOfWork);

            if (unitOfWork.Outer == null)
            {
                CallContext.FreeNamedDataSlot(ContextKey);
                return;
            }

            //Restore outer UOW
            var outerUnitOfWorkKey = unitOfWork.Outer.Id;
            if (!UnitOfWorkDictionary.TryGetValue(outerUnitOfWorkKey, out unitOfWork))
            {
                //No outer UOW
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
