using System;
using System.Collections.Generic;

namespace DotPlatform.Events.Startup
{
    /// <summary>
    /// 表示实现该接口的对象为事件处理者查找
    /// </summary>
    public interface IEventHandlerFinder
    {
        /// <summary>
        /// 查找出所有的事件处理对象类
        /// </summary>
        /// <returns></returns>
        IEnumerable<Type> FindAll();
    }
}
