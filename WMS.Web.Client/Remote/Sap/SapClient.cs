using System;
using DotPlatform.Plugin.SAP.Rfc;
using WMS.Web.Client.Models;
using DotPlatform.Extensions;

namespace WMS.Web.Client.Remote.Sap
{
    /// <summary>
    /// SAP 客户端。用于 WMS 与 SAP 系统之间的交互
    /// </summary>
    public static class SapClient
    {
        /// <summary>
        /// SAP 连接字符名称
        /// </summary>
        public const string ConnectionName =
#if DEBUG
            "SapRfc:SAPDEV";
#else
            "SapRfc:SAPPRD";
#endif

        /// <summary>
        /// SAP 中过账。
        /// ture, 过账成功；false，过账失败
        /// </summary>
        /// <param name="inhouseNo">单据号</param>
        /// <param name="wipNo">来料工单</param>
        /// <param name="plant">来料工厂</param>
        /// <param name="partNumber">收料的料号</param>
        /// <param name="qty">收料数量</param>
        /// <param name="destplant">收料工厂</param>
        /// <param name="destlocation">收料库位</param>
        /// <param name="isNotVirtual">是否是虚拟过账, true 表示非虚拟过账; false 表示虚拟过账</param>
        /// <param name="postedDate">过账日期</param>
        /// <param name="materialDoc">若成功，回传 SAP 物料单号，否则为 null</param>
        /// <param name="errorMessage">若失败，回传 SAP 异常信息，否则为 null 或 Empty</param>
        /// <returns></returns>
        public static bool Post(string inhouseNo, string wipNo, string plant, string partNumber, int qty,
            string destplant, string destlocation, bool isNotVirtual, DateTime postedDate, 
            out string materialDoc, out string errorMessage)
        {
            // "GRNUM": CHAR  入库单号
            // "AUFNR": CHAR  工单号
            // "WERKS": CHAR  工单工厂
            // "MATNR": CHAR  料号
            // "ENTRY_QNT": BCD  收料数量
            // "WERKS_GR": CHAR  收料工厂
            // "LGORT_GR": CHAR  收料库位
            // "FLAG": CHAR  是否虚拟工单收料
            // "DATUM": CHAR  过账日期

            try
            {
                using (var conn = RfcConnectionFactory.Plain.Create(ConnectionName))
                {
                    var command = conn.CreateCommand();
                    var rfcResult = command.Execute("ZMM_BAPI_MVT101_CREATE",
                        new
                        {
                            GRNUM = inhouseNo,
                            AUFNR = wipNo,
                            WERKS = plant,
                            MATNR = partNumber,
                            ENTRY_QNT = qty,
                            WERKS_GR = destplant,
                            LGORT_GR = destlocation,
                            FLAG = isNotVirtual,
                            DATUM = postedDate
                        });

                    var result = rfcResult.GetList<ZMVT_101_CN>("ZMVT_OUT")[0];

                    materialDoc = result.MBLNR1;
                    errorMessage = result.MESSAGE1;
                    return !materialDoc.IsNullOrWhiteSpace();
                }
            }
            catch(Exception ex)
            {
                materialDoc = null;
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}
