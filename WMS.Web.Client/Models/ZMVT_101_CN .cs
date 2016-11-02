namespace WMS.Web.Client.Models
{
    /// <summary>
    /// mb31
    /// </summary>
    public class ZMVT_101_CN
    {
        /// <summary>
        /// 物料凭证编号
        /// Number of Material Document
        /// </summary>
        public string MBLNR1 { get; set; }

        /// <summary>
        /// 物料凭证年度
        /// Material Document Year	
        /// </summary>
        public string MJAHR { get; set; }

        /// <summary>
        /// 订单号
        /// Order Number
        /// </summary>
        public string AUFNR { get; set; }

        /// <summary>
        /// 物料编号
        /// Material Number
        /// </summary>
        public string MATNR { get; set; }

        /// <summary>
        /// 工厂
        /// Plant
        /// </summary>
        public string WERKS { get; set; }

        /// <summary>
        /// Plant (收料工厂)
        /// </summary>
        public string WERKS_GR { get; set; }

        /// <summary>
        /// Storage Location (库存地点)
        /// </summary>
        public string LGORT_GR { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public string ENTRY_QNT { get; set; }

        /// <summary>
        /// 移动类型（库存管理）
        /// Movement Type (Inventory Management)
        /// </summary>
        public string BWART { get; set; }

        /// <summary>
        /// 借方/货方标识
        /// Debit/Credit Indicator
        /// </summary>
        public string SHKZG { get; set; }

        /// <summary>
        /// 入库单号
        /// </summary>
        public string GRNUM { get; set; }

        /// <summary>
        /// Message Text
        /// </summary>
        public string MESSAGE1 { get; set; }

        /// <summary>
        /// 凭证中的凭证日期
        /// Document Date in Document
        /// </summary>
        public string DOC_DATE { get; set; }

        /// <summary>
        /// Time
        /// </summary>
        public string DOC_UZEIT { get; set; }
    }
}
