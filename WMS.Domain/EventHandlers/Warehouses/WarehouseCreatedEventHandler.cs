using DotPlatform.Events;
using WMS.Domain.Events.Warehouses;
using DotPlatform.Domain.Uow;
using WMS.Domain.Repositories;
using DotPlatform.Domain.Entities.Extensions;
using WMS.Domain.Models.Warehouses;

namespace WMS.Domain.EventHandlers.Warehouses
{
    /// <summary>
    /// 仓储创建事件处理者
    /// </summary>
    public class WarehouseCreatedEventHandler : IEventHandler<WarehouseCreatedEvent>
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseCreatedEventHandler(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        [UnitOfWork]
        public virtual void Handle(WarehouseCreatedEvent e)
        {
            var warehouse = e.Source.Cast<Warehouse>();

            _warehouseRepository.Add(warehouse);
        }
    }
}
