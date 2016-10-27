namespace WMS.Domain.Models.Inbounds
{
    /// <summary>
    /// 入库单单据状态
    /// </summary>
    public enum StockInStatus
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
