using System;

namespace DotPlatform.Domain.Uow
{
    /// <summary>
    /// 工作单元失败的事件参数
    /// </summary>
    public class UnitOfWorkFailedEventArgs : EventArgs
    {
        /// <summary>
        /// 获取异常信息
        /// </summary>
        public Exception Exception { get; private set; }

        /// <summary>
        /// 初始化一个新的<c>UnitOfWorkFailedEventArgs</c>实例
        /// </summary>
        /// <param name="exception">导致异常的信息</param>
        public UnitOfWorkFailedEventArgs(Exception exception)
        {
            Exception = exception;
        }
    }
}
