using DotPlatform.Extensions;
using System.Collections.Generic;
using WMS.Web.Client.Models;
using WMS.Web.Client.SFISEtlService;

namespace WMS.Web.Client.Remote.Sfis
{
    /// <summary>
    /// 基于 SFIS Web Service 的客户端
    /// </summary>
    public class SfisServiceClient
    {
        /// <summary>
        /// 获取 SFIS 
        /// </summary>
        /// <param name="inhouseNo">单据名称</param>
        /// <param name="plant">工厂</param>
        /// <returns></returns>
        public List<QryData> GetSfisRv<T>(string inhouseNo, string plant)
        {
            var param = "<root>";
            param += "      <METHOD ID='ETLSO.QryFQCInhouseMasterSN001'/>";
            param += "      <FQC_INHOUSE_MASTER_SN001>";
            param += $"         <INHOUSE_NO>{inhouseNo}</INHOUSE_NO>";
            param += "      </FQC_INHOUSE_MASTER_SN001>";
            param += "</root>";

            var client = new ETL_ServiceSoapClient();
            var ds = client.SFIS_Rv(param, plant);
            if (ds == null)
                return null;

            return ds.Tables[0].ToList<QryData>();
        }
    }
}
