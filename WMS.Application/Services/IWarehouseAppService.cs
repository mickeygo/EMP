using System;
using System.Collections.Generic;
using DotPlatform.Application.Services;
using WMS.DataTransferObject.Dtos;

namespace WMS.Application.Services
{
    /// <summary>
    /// 仓库管理应用服务。
    /// </summary>
    public interface IWarehouseAppService : IApplicationService
    {
        /// <summary>
        /// 获取所有的仓库
        /// </summary>
        /// <returns></returns>
        List<WarehouseDto> GetAllWarehouses();

        /// <summary>
        /// 获取仓库
        /// </summary>
        /// <param name="id">仓库 Id</param>
        /// <returns></returns>
        WarehouseDto GetWarehouse(Guid id);

        /// <summary>
        /// 创建仓库
        /// </summary>
        /// <param name="model"></param>
        void CreateWarehouse(WarehouseDto model);


        List<ZoneDto> GetZones(Guid warehouseId);

        ZoneDto GetZone(Guid zoneId);

        void CreateZone(ZoneDto zone);


        List<ShelfDto> GetShelfs(Guid zoneId);

        ShelfDto GetShelf(Guid shelfId);

        void CreateShelf(ShelfDto shelf);


        List<LocationDto> GetLocations(Guid shelfId);

        LocationDto GetLocation(Guid locationId);

        void CreateLocation(LocationDto location);
    }
}
