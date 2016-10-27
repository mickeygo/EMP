using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using DotPlatform.Plugin.SAP.Rfc.Types;
using DotPlatform.Utils;
using DotPlatform.Plugin.SAP.Rfc.Annotations;
using SAP.Middleware.Connector;
using DotPlatform.Plugin.SAP.Rfc.Extensions;

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
        /// 创建 Table 结构
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="parameterObject"></param>
        /// <returns></returns>
        public IRfcTable CreateTable(RfcTableMetadata metadata, object parameterObject)
        {
            var table = metadata.CreateTable();
            var structureMetadata = metadata.LineType;

            var enumerable = parameterObject as IEnumerable;
            if (enumerable == null)
            {
                var row = CreateStructure(structureMetadata, parameterObject);
                table.Append(row);
            }
            else
            {
                var enumerator = enumerable.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    object current = enumerator.Current;
                    var row = CreateStructure(structureMetadata, current);
                    table.Append(row);
                }
            }
            return table;
        }

        /// <summary>
        /// 创建 Structure 结构
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="parameterObject"></param>
        /// <returns></returns>
        public IRfcStructure CreateStructure(RfcStructureMetadata metadata, object parameterObject)
        {
            if (parameterObject == null)
                return null;

            var structure = metadata.CreateStructure();
            var type = parameterObject.GetType();

            for (int i = 0; i < metadata.FieldCount; i++)
            {
                var fieldMetaData = metadata[i];
                var formattedValue = this.ToRemoteValue(fieldMetaData.GetAbapDataType(), parameterObject);
                structure.SetValue(fieldMetaData.Name, formattedValue);
            }
            return structure;
        }

        /// <summary>
        /// 将 Rfc Structure 转换为 .NET 对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="structure"></param>
        /// <returns></returns>
        public T FromStructure<T>(IRfcStructure structure)
        {
            var type = typeof(T);
            var returnObject = default(T);
            if (!type.Equals(typeof(string)))
                returnObject = Activator.CreateInstance<T>();

            var propertyTypeCollection = ReflectionHelper.Resolve(type);
            IDictionary<string, string> mappingDic = null;

            for (int i = 0; i < structure.Metadata.FieldCount; i++)
            {
                var fieldName = structure.Metadata[i].Name;
                var value = structure.GetValue(fieldName);

                if (string.IsNullOrEmpty(fieldName))
                    return FromRemoteValue<T>(value);

                if (propertyTypeCollection.ContainsKey(fieldName))
                {
                    var formattedValue = FromRemoteValue(propertyTypeCollection[fieldName], value);
                    ReflectionHelper.SetValue(returnObject, fieldName, formattedValue);
                }
                else
                {
                    // Attribute
                    // 获取对象中 RfcMapAttribute 特性
                    mappingDic = mappingDic ?? GetMappingProperty(type);

                    if (mappingDic.ContainsKey(fieldName))
                    {
                        var protertyName = mappingDic[fieldName];
                        var formattedValue = FromRemoteValue(propertyTypeCollection[protertyName], value);
                        ReflectionHelper.SetValue(returnObject, protertyName, formattedValue);
                    }
                }
            }

            return returnObject;
        }

        // Key => Attribute FieldName; Value => ProtertyName
        private IDictionary<string, string> GetMappingProperty(Type type)
        {
            return (from item in ReflectionHelper.GetCustomAttributesOfProperty<RfcMapAttribute>(type)
                    select new { item.Value.FieldName, ProtertyName = item.Key }
                    ).ToDictionary(k => k.FieldName, v => v.ProtertyName);
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
