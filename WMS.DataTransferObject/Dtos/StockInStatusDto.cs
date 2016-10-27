using DotPlatform.AutoMapper;
using WMS.Domain.Models.Inbounds;

namespace WMS.DataTransferObject.Dtos
{
    /// <summary>
    /// 入库单单据状态
    /// </summary>
    [AutoMapFrom(typeof(StockInStatus))]
    public enum StockInStatusDto
    {
        /// <summary>
        /// 已开单
        /// </summary>
        Opened = 1,

        /// <summary>
        /// 已过账
        /// </summary>
        Posted = 2,

        /// <summary>
        /// 单据已关闭
        /// </summary>
        Closed = 3
    }
}
