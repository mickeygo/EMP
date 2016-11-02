using System;

namespace DotPlatform.Plugin.SAP.Rfc.Annotations
{
    /// <summary>
    /// 对应的 Rfc 字段。
    /// 用于将 SAP RFC 中的字段值映射到有该特性的字段
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class RfcMapAttribute : Attribute
    {
        /// <summary>
        /// 获取对应的 Rfc 字段名称
        /// </summary>
        public string FieldName { get; private set; }

        /// <summary>
        /// 初始化一个新的<see cref="RfcMapAttribute"/>实例
        /// </summary>
        /// <param name="fieldName">对应的 Rfc 字段名称</param>
        public RfcMapAttribute(string fieldName)
        {
            FieldName = fieldName;
        }
    }
}
