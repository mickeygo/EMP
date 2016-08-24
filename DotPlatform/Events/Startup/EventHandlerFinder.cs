using System;
using System.Collections.Generic;
using System.Linq;
using DotPlatform.Reflection;

namespace DotPlatform.Events.Startup
{
    /// <summary>
    /// 事件处理者查找类.
    /// 找出所有的接口为<see cref="IEventHandler"/>的实体类
    /// </summary>
    public class EventHandlerFinder : IEventHandlerFinder
    {
        private readonly ITypeFinder _typeFinder;

        public EventHandlerFinder(ITypeFinder typeFinder)
        {
            _typeFinder = typeFinder;
        }

        public IEnumerable<Type> FindAll()
        {
            return _typeFinder.Find(t => t.IsClass
                    && !t.IsAbstract
                    && t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEventHandler<>)));
        }
    }
}
