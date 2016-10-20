namespace WMS.Web.Client.Models
{
    /// <summary>
    /// SFIS 的入库货物
    /// </summary>
    public class InhouseGoods
    {
        /// <summary>
        /// 入库单号
        /// </summary>
        public string INHOUSE_NO { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        public string WERKS { get; set; }

        /// <summary>
        /// 工单号
        /// </summary>
        public string WIP_NO { get; set; }

        /// <summary>
        /// 料号
        /// </summary>
        public string ITEM_NO { get; set; }

        /// <summary>
        /// Barcode
        /// </summary>
        public string BARCODE_NO { get; set; }

        /// <summary>
        /// 箱号
        /// </summary>
        public string BOX_NO { get; set; }

        /// <summary>
        /// 目的仓库
        /// </summary>
        public string LGORT { get; set; }
    }
}
