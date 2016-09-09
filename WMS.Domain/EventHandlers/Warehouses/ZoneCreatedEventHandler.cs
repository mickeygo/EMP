using DotPlatform.Events;
using WMS.Domain.Events.Warehouses;
using DotPlatform.Domain.Uow;
using WMS.Domain.Repositories;
using DotPlatform.Domain.Entities.Extensions;
using WMS.Domain.Models.Warehouses;

namespace WMS.Domain.EventHandlers.Warehouses
{
    /// <summary>
    /// 仓库区域创建事件处理者
    /// </summary>
    public class ZoneCreatedEventHandler : IEventHandler<ZoneCreatedEvent>
    {
        private readonly IZoneRepository _zoneRepository;

        public ZoneCreatedEventHandler(IZoneRepository zoneRepository)
        {
            _zoneRepository = zoneRepository;
        }

        [UnitOfWork]
        public virtual void Handle(ZoneCreatedEvent e)
        {
            var zone = e.Source.Cast<Zone>();

            _zoneRepository.Add(zone);
        }
    }
}
