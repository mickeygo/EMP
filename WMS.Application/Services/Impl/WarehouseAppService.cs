using System;
using System.Collections.Generic;
using DotPlatform.Application.Services;
using DotPlatform.Events.Bus;
using WMS.DataTransferObject.Dtos;
using WMS.Domain.Events.Warehouses;
using WMS.Domain.Models.Warehouses;
using WMS.Domain.Repositories.Query;
using DotPlatform.AutoMapper;

namespace WMS.Application.Services.Impl
{
    /// <summary>
    /// 仓库管理应用服务
    /// </summary>
    public class WarehouseAppService : ApplicationService, IWarehouseAppService
    {
        private readonly IEventBus _eventBus;
        private readonly IWarehouseQueryRepository _warehouseQueryRepository;
        private readonly IZoneQueryRepository _zoneQueryRepository;
        private readonly IShelfQueryRepository _shelfQueryRepository;
        private readonly ILocationQueryRepository _locationQueryRepository;

        public WarehouseAppService(IEventBus eventBus, 
            IWarehouseQueryRepository warehouseQueryRepository,
            IZoneQueryRepository zoneQueryRepository,
            IShelfQueryRepository shelfQueryRepository,
            ILocationQueryRepository locationQueryRepository)
        {
            _eventBus = eventBus;
            _warehouseQueryRepository = warehouseQueryRepository;
            _zoneQueryRepository = zoneQueryRepository;
            _shelfQueryRepository = shelfQueryRepository;
            _locationQueryRepository = locationQueryRepository;
        }

        public List<WarehouseDto> GetAllWarehouses()
        {
            return _warehouseQueryRepository.GetAllList().MapTo<WarehouseDto>();
        }

        public WarehouseDto GetWarehouse(Guid id)
        {
            return _warehouseQueryRepository.FirstOrDefault(id).MapTo<WarehouseDto>();
        }

        public void CreateWarehouse(WarehouseDto model)
        {
            var warehouse = new Warehouse(model.Name, model.DisplayName, model.Description, model.Length, model.Length, model.Height);
            _eventBus.Publish(new WarehouseCreatedEvent(warehouse));
        }

        public List<ZoneDto> GetZones(Guid warehouseId)
        {
            return _zoneQueryRepository.GetAllList(z => z.WarehouseId == warehouseId).MapTo<ZoneDto>();
        }

        public ZoneDto GetZone(Guid zoneId)
        {
            return _zoneQueryRepository.FirstOrDefault(zoneId).MapTo<ZoneDto>();
        }

        public void CreateZone(ZoneDto zone)
        {
            throw new NotImplementedException();
        }

        public List<ShelfDto> GetShelfs(Guid zoneId)
        {
            return _shelfQueryRepository.GetAllList(s => s.ZoneId == zoneId).MapTo<ShelfDto>();
        }

        public ShelfDto GetShelf(Guid shelfId)
        {
            return _shelfQueryRepository.FirstOrDefault(shelfId).MapTo<ShelfDto>();
        }

        public void CreateShelf(ShelfDto shelf)
        {
            throw new NotImplementedException();
        }

        public List<LocationDto> GetLocations(Guid shelfId)
        {
            return _locationQueryRepository.GetAllList(l => l.ShelfId == shelfId).MapTo<LocationDto>();
        }

        public LocationDto GetLocation(Guid locationId)
        {
            return _locationQueryRepository.FirstOrDefault(locationId).MapTo<LocationDto>();
        }

        public void CreateLocation(LocationDto location)
        {
            throw new NotImplementedException();
        }

        protected override void Close()
        {
            _warehouseQueryRepository?.Dispose();
            _zoneQueryRepository?.Dispose();
            _shelfQueryRepository?.Dispose();
            _locationQueryRepository?.Dispose();
        }
    }
}
