using DotPlatform.Events;
using WMS.Domain.Events.Warehouses;
using DotPlatform.Domain.Uow;
using WMS.Domain.Repositories;
using DotPlatform.Domain.Entities.Extensions;
using WMS.Domain.Models.Warehouses;

namespace WMS.Domain.EventHandlers.Warehouses
{
    /// <summary>
    /// 仓库储位创建事件处理者
    /// </summary>
    public class LocationCreatedEventHandler : IEventHandler<LocationCreatedEvent>
    {
        private readonly ILocationRepository _loationRepository;

        public LocationCreatedEventHandler(ILocationRepository locationRepository)
        {
            _loationRepository = locationRepository;
        }

        [UnitOfWork]
        public virtual void Handle(LocationCreatedEvent e)
        {
            var location = e.Source.Cast<Location>();

            _loationRepository.Add(location);
        }
    }
}
