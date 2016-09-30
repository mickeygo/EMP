using System;
using SAP.Middleware.Connector;

namespace DotPlatform.Plugin.SAP.Rfc
{
    /// <summary>
    /// RFC 对象与 .NET 对象直接的映射器
    /// </summary>
    public abstract class RfcStructureMapper
    {
        private RfcElementMetadata[] _elementMetadataArray;

        public void Map(IRfcTable table)
        {
            foreach (var row in table)
            {
                for (var i = 0; i < table.ElementCount; i++)
                {
                    var metadata = _elementMetadataArray[i];
                }
            }

            // RfcElementMetadata 元数据，描述 Table 每列的信息

            // IRfcStructure Table 每行的数据信息
        }

        private void ElementMetadata(IRfcTable table)
        {
            for (var i = 0; i < table.ElementCount; i++)
            {
                _elementMetadataArray[i] = table.GetElementMetadata(i);
            }
        }

        private Type ConvertToAspNetDataType(RfcDataType rfcDataType)
        {
            switch (rfcDataType)
            {
                case RfcDataType.CHAR:
                    return typeof(string);
                case RfcDataType.STRING:
                    return typeof(string);
                case RfcDataType.BCD:
                    return typeof(decimal);
                case RfcDataType.INT2:
                    return typeof(int);
                case RfcDataType.INT4:
                    return typeof(int);
                case RfcDataType.FLOAT:
                    return typeof(double);
                case RfcDataType.DATE:
                    return typeof(DateTime);
                default:
                    return typeof(string);
            }
        }
    }
}
