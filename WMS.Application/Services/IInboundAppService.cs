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
        /// 获取入库单对象
        /// </summary>
        /// <param name="docNo">入库单单据号</param>
        /// <returns></returns>
        StockInDto GetStockIn(string docNo);

        /// <summary>
        /// 是否存在该入库单
        /// </summary>
        /// <param name="docNo">入库单单据号</param>
        /// <returns></returns>
        bool ExistStockIn(string docNo);

        /// <summary>
        /// 创建入库单
        /// </summary>
        /// <param name="model">入库单据</param>
        void CreateStockIn(StockInDto model);

        /// <summary>
        /// 入库单单据过账
        /// </summary>
        /// <param name="docId">入库单 Id</param>
        /// <param name="postBy">过账人</param>
        /// <param name="postDate">过账日期</param>
        /// <param name="certificate">回执单据</param>
        /// <param name="ackMessage">回执信息</param>
        void Post(Guid docId, string postBy, DateTime postDate, string certificate, string ackMessage);
    }
}
