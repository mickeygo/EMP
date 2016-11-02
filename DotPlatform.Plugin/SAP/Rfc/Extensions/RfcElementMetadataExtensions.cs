using DotPlatform.Plugin.SAP.Rfc.Exceptions;
using DotPlatform.Plugin.SAP.Rfc.Types;
using SAP.Middleware.Connector;

namespace DotPlatform.Plugin.SAP.Rfc.Extensions
{
    /// <summary>
    /// Rfc 元素元数据扩展类
    /// </summary>
    public static class RfcElementMetadataExtensions
    {
        /// <summary>
        /// 将 Rfc 元素映射到 <see cref="AbapDataType"/> 对象
        /// </summary>
        /// <param name="metadata">Rfc 元素元数据</param>
        /// <returns></returns>
        public static AbapDataType GetAbapDataType(this RfcElementMetadata metadata)
        {
            switch (metadata.DataType)
            {
                case RfcDataType.CHAR:
                case RfcDataType.STRING:
                    return AbapDataType.CHAR;

                case RfcDataType.DATE:
                    return AbapDataType.DATE;

                case RfcDataType.BCD:
                    return AbapDataType.DECIMAL;

                case RfcDataType.FLOAT:
                    return AbapDataType.DOUBLE;

                case RfcDataType.INT1:
                    return AbapDataType.BYTE;

                case RfcDataType.INT2:
                    return AbapDataType.SHORT;

                case RfcDataType.INT4:
                    return AbapDataType.INTEGER;

                case RfcDataType.NUM:
                    return AbapDataType.NUMERIC;

                case RfcDataType.STRUCTURE:
                    return AbapDataType.STRUCTURE;

                case RfcDataType.TABLE:
                    return AbapDataType.TABLE;

                case RfcDataType.TIME:
                    return AbapDataType.TIME;

                case RfcDataType.BYTE:
                case RfcDataType.XSTRING:
                    return AbapDataType.BYTE;

                case RfcDataType.CDAY:
                case RfcDataType.CLASS:
                case RfcDataType.DTDAY:
                case RfcDataType.DTMONTH:
                case RfcDataType.DTWEEK:
                case RfcDataType.TMINUTE:
                case RfcDataType.TSECOND:
                case RfcDataType.UNKNOWN:
                case RfcDataType.UTCLONG:
                case RfcDataType.UTCMINUTE:
                case RfcDataType.UTCSECOND:
                default:
                    throw new RfcMappingException($"Could not map RfcDataType '{metadata.DataType}' to AbapDataType");

            }
        }
    }
}
