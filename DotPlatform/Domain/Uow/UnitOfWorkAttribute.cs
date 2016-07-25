using System;
using System.Linq;
using System.Reflection;
using System.Transactions;

namespace DotPlatform.Domain.Uow
{
    /// <summary>
    /// 工作单元特性，仅用于方法。
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple =false, Inherited = false)]
    public class UnitOfWorkAttribute : Attribute
    {
        #region Properties

        /// <summary>
        /// 获取一个<see cref="bool?"/>值，表示工作单元是否是事务级别（使用事务域<see cref="TransactionScope"/>）。
        /// 默认为 true.
        /// </summary>
        public bool? IsTransactional { get; private set; } = true;

        /// <summary>
        /// 获取一个<see cref="TimeSpan?"/>值，表示事务超时时间（毫秒）
        /// </summary>
        public TimeSpan? Timeout { get; private set; }

        /// <summary>
        /// 获取或设置事务域
        /// </summary>
        public TransactionScopeOption? Scope { get; set; }

        /// <summary>
        /// 获取或设置一个<see cref="IsolationLevel"/>值，用于定义事务的隔离级别。
        /// </summary>
        public IsolationLevel? IsolationLevel { get; set; }

        /// <summary>
        /// 获取一个<see cref="bool?"/>值，表示不对方法使用工作单元。
        /// 若已开始了工作单元，该属性会被忽略。
        /// 默认为 false.
        /// </summary>
        public bool IsDisabled { get; set; }

        #endregion

        #region Ctor

        /// <summary>
        /// 初始化一个新的<see cref="UnitOfWorkAttribute"/>实例
        /// </summary>
        public UnitOfWorkAttribute()
        {

        }

        /// <summary>
        /// 初始化一个新的<see cref="UnitOfWorkAttribute"/>实例
        /// </summary>
        /// <param name="isTransactional">是否启用事务</param>
        public UnitOfWorkAttribute(bool isTransactional)
        {
            IsTransactional = isTransactional;
        }

        /// <summary>
        /// 初始化一个新的<see cref="UnitOfWorkAttribute"/>实例
        /// </summary>
        /// <param name="isTransactional">是否启用事务</param>
        /// <param name="timeout">超时时间，毫秒</param>
        public UnitOfWorkAttribute(bool isTransactional, int timeout)
        {
            IsTransactional = isTransactional;
            Timeout = TimeSpan.FromMilliseconds(timeout);
        }

        /// <summary>
        /// 初始化一个新的<see cref="UnitOfWorkAttribute"/>实例
        /// </summary>
        /// <param name="isolationLevel">隔离事务级别</param>
        public UnitOfWorkAttribute(IsolationLevel isolationLevel)
        {
            IsolationLevel = isolationLevel;
        }

        /// <summary>
        ///  初始化一个新的<see cref="UnitOfWorkAttribute"/>实例
        /// </summary>
        /// <param name="isolationLevel">隔离事务级别</param>
        /// <param name="timeout">超时时间，毫秒</param>
        public UnitOfWorkAttribute(IsolationLevel isolationLevel, int timeout)
        {
            IsolationLevel = isolationLevel;
            Timeout = TimeSpan.FromMilliseconds(timeout);
        }

        #endregion

        /// <summary>
        /// 获取对象成员的工作单元特性。若没有则返回 null.
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <returns></returns>
        internal static UnitOfWorkAttribute GetUnitOfWorkAttributeOrNull(MemberInfo methodInfo)
        {
            var attrs = methodInfo.GetCustomAttributes(typeof(UnitOfWorkAttribute), false);
            if (attrs.Any())
            {
                return (UnitOfWorkAttribute)attrs[0];
            }

            // Todo: 是否要对 IRepository 和 ApplicationService 启动工作单元
            //if (UnitOfWorkHelper.IsConventionalUowClass(methodInfo.DeclaringType))
            //{
            //    return new UnitOfWorkAttribute(); //Default
            //}

            return null;
        }

        internal UnitOfWorkOptions CreateOptions()
        {
            return new UnitOfWorkOptions
            {
                IsTransactional = IsTransactional,
                IsolationLevel = IsolationLevel,
                Timeout = Timeout,
                Scope = Scope
            };
        }
    }
}
