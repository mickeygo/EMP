using System;
using System.Collections.Generic;
using DotPlatform.Plugin.SAP.Rfc.Types;

namespace DotPlatform.Plugin.SAP.Rfc
{
    /// <summary>
    /// RFC 对象与 .NET 对象直接的映射器
    /// </summary>
    public abstract class RfcStructureMapper
    {
        private RfcValueMapper _valueMapper;

        public RfcStructureMapper(RfcValueMapper valueMapper)
        {
            _valueMapper = valueMapper;
        }

        /// <summary>
        /// 将 ABAP 对象转换为 .NET 对象
        /// </summary>
        /// <typeparam name="T">要获取的对象类型</typeparam>
        /// <param name="value">对象值</param>
        /// <returns></returns>
        public T FromRemoteValue<T>(object value)
        {
            return (T)_valueMapper.FromRemoteValue(typeof(T), value);
        }

        /// <summary>
        /// 将 ABAP 对象转换为 .NET 对象
        /// </summary>
        /// <param name="type">要获取的对象类型</param>
        /// <param name="value">对象值</param>
        /// <returns></returns>
        public object FromRemoteValue(Type type, object value)
        {
            return _valueMapper.FromRemoteValue(type, value);
        }

        /// <summary>
        /// 将 .NET 对象转换为 ABAP 对象
        /// </summary>
        /// <param name="remoteType">ABAP 对象类型</param>
        /// <param name="value">对象</param>
        /// <returns></returns>
        public object ToRemoteValue(AbapDataType remoteType, object value)
        {
            return _valueMapper.ToRemoteValue(remoteType, value);
        }
    }
}
