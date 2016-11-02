namespace DotPlatform.Plugin.SAP.Rfc.Plain
{
    /// <summary>
    /// 基于 Plain 的 RFC 对象与 .NET 对象直接的映射器
    /// </summary>
    public class PlainRfcStructureMapper : RfcStructureMapper
    {
        /// <summary>
        /// 初始化一个新的<see cref="RfcValueMapper"/>实例
        /// </summary>
        /// <param name="valueMapper">Rfc 与 .NET 单值映射关系对象</param>
        public PlainRfcStructureMapper(RfcValueMapper valueMapper) : base(valueMapper)
        {
        }
    }
}
