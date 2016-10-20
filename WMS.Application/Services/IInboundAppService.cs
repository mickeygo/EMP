using System;
using DotPlatform.Application.Services;
using WMS.DataTransferObject.Dtos;

namespace WMS.Application.Services
{
    /// <summary>
    /// 入库应用服务
    /// </summary>
    public interface IInboundAppService : IApplicationService
    {
        /// <summary>
        /// 创建入库单
        /// </summary>
        /// <param name="model">入库单据</param>
        void CreateStockIn(StockInDto model);

        /// <summary>
        /// 来料入库
        /// </summary>
        /// <param name="docId">入库单 Id</param>
        /// <param name="inboundBy">入库人</param>
        /// <param name="inboundDate">入库日期</param>
        void Inbound(Guid docId, string inboundBy, DateTime inboundDate);
    }
}
