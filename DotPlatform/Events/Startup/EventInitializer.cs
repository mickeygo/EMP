using System;
using System.Linq;
using System.Collections.Generic;
using DotPlatform.Configuration;
using DotPlatform.Dependency;
using DotPlatform.Events.Registrator;
using DotPlatform.Domain.Uow;

namespace DotPlatform.Events.Startup
{
    /// <summary>
    /// 事件处理者注册容器初始化
    /// </summary>
    internal class EventInitializer : IApplicationInitializer
    {
        private readonly IIocManager _iocManager;
        private readonly IEventHandlerFinder _eventHandlerFinder;

        public EventInitializer()
        {
            _iocManager = IocManager.Instance;
            _eventHandlerFinder = _iocManager.Resolve<IEventHandlerFinder>();
        }

        public void Initialize()
        {
            var eventHandlerTypes = _eventHandlerFinder.FindAll().ToList();

            // Mapping
            RegisterEventHandlerMapping(eventHandlerTypes);

            // Ioc
            RegisterIoc(eventHandlerTypes);
        }

        private void RegisterIoc(IEnumerable<Type> eventHandlerTypes)
        {
            foreach (var type in eventHandlerTypes)
            {
                _iocManager.RegisterWithInterceptor(type, IocLifeStyle.Transient, typeof(UnitOfWorkInterceptor));
            }

            _iocManager.Build();
        }

        private void RegisterEventHandlerMapping(IEnumerable<Type> eventHandlerTypes)
        {
            var registor = EventHandlerRegistrator.Instance;
            foreach (var eventHandlerType in eventHandlerTypes)
            {
                registor.Register(eventHandlerType);
            }
        }
    }
}
