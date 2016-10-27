using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using DotPlatform.Plugin.SAP.Rfc.Types;
using DotPlatform.Extensions;
using DotPlatform.Plugin.SAP.Rfc.Annotations;

namespace DotPlatform.Plugin.SAP.Rfc
{
    /// <summary>
    /// Rfc 与 .NET 单值映射关系基类
    /// </summary>
    public abstract class RfcValueMapper
    {
        /// <summary>
        /// 基于逗号（","）的数字格式化
        /// </summary>
        protected NumberFormatInfo CommaDecimalNumberFormat
        {
            get { return new NumberFormatInfo() { NumberDecimalSeparator = "," }; }
        }

        /// <summary>
        /// 基于点（"."）的数字格式化
        /// </summary>
        protected NumberFormatInfo PeriodDecimalNumberFormat
        {
            get { return new NumberFormatInfo() { NumberDecimalSeparator = "." }; }
        }

        #region Public Methods

        /// <summary>
        /// 将 ABAP 对象转换为 .NET 对象
        /// </summary>
        /// <param name="type">要转换的 .NET 类型</param>
        /// <param name="value">ABAP 对象实例</param>
        /// <returns></returns>
        public virtual object FromRemoteValue(Type type, object value)
        {
            if (type.Equals(typeof(string)))
                return value == null ? "" : (string)value;

            if (value == null || value.ToString().Equals(""))
            {
                if (type.IsNullable())
                    return null;

                return Activator.CreateInstance(type);
            }

            if (type.Equals(typeof(bool)))
                return AbapBool.FromString(value.ToString());

            if (type.Equals(typeof(DateTime)))
                return AbapDateTime.FromString(value.ToString());

            if (type.Equals(typeof(DateTime?)))
                return AbapDateTime.FromString(value.ToString(), true);

            if (type.Equals(typeof(decimal)))
            {
                if (value.ToString().StartsWith("*"))
                    throw new InvalidOperationException($"SAP truncated value {value}. Operation aborted");

                return Convert.ToDecimal(value, value.ToString().Contains(",") ? this.CommaDecimalNumberFormat : this.PeriodDecimalNumberFormat);
            }

            if (type.Equals(typeof(double)))
            {
                if (value.ToString().StartsWith("*"))
                    throw new InvalidOperationException($"SAP truncated value {value}. Operation aborted");

                return Convert.ToDouble(value, value.ToString().Contains(",") ? this.CommaDecimalNumberFormat : this.PeriodDecimalNumberFormat);
            }

            if (type.Equals(typeof(byte[])))
                return ToBytes(value);

            if (type.Equals(typeof(Stream)))
                return new MemoryStream(ToBytes(value));

            return Convert.ChangeType(value, type);
        }

        /// <summary>
        /// 将 .NET 对象转换为 ABAP 对象
        /// </summary>
        /// <param name="remoteType">要转换的 ABAP 对象类型</param>
        /// <param name="value">.NET 对象实例</param>
        /// <returns></returns>
        public virtual object ToRemoteValue(AbapDataType remoteType, object value)
        {
            if (value == null)
                return null;

            Type valueType = value.GetType();

            if (valueType == typeof(bool))
                return AbapBool.ToString((bool)value);

            if (valueType.Equals(typeof(double)))
                return ((double)value).ToString(GetNumberFormat());

            if (valueType.Equals(typeof(float)))
                return ((float)value).ToString(GetNumberFormat());

            if (valueType.Equals(typeof(decimal)))
                return ((decimal)value).ToString(GetNumberFormat());

            if (remoteType == AbapDataType.DATE)
                return AbapDateTime.ToDateString((DateTime)value);

            if (remoteType == AbapDataType.TIME)
                return AbapDateTime.ToTimeString((DateTime)value);

            if (valueType.Equals(typeof(DateTime)))
                return AbapDateTime.ToDateString((DateTime)value);

            return value;
        }

        #endregion

        #region Protected Methods

        protected abstract NumberFormatInfo GetNumberFormat();

        #endregion

        #region Private Methods

        private byte[] ToBytes(object value)
        {
            if (value is string)
                return Convert.FromBase64String(value.ToString());

            return (byte[])value;
        }

        private string GetAlias(PropertyInfo property)
        {
            var attribute = property.GetCustomAttribute<RfcMapAttribute>();
            return attribute?.FieldName;
        }

        #endregion
    }
}
