using System.Collections.Generic;
using SAP.Middleware.Connector;

namespace DotPlatform.Plugin.SAP.Rfc.Plain
{
    /// <summary>
    /// 基于 Plain 的 Rfc 结果
    /// </summary>
    public class PlainRfcResult : IRfcResult
    {
        private readonly IRfcFunction _function;
        private readonly RfcStructureMapper _structureMapper;

        /// <summary>
        /// 初始化一个新的<see cref="PlainRfcResult"/>实例
        /// </summary>
        /// <param name="function">Rfc 函数</param>
        /// <param name="structureMapper">基于 Plain 的数据结构映射器</param>
        public PlainRfcResult(IRfcFunction function, RfcStructureMapper structureMapper)
        {
            _function = function;
            _structureMapper = structureMapper;
        }

        public T Get<T>(string name)
        {
            var value = _function.GetValue(name);
            if (value is IRfcStructure)
                return _structureMapper.FromStructure<T>(value as IRfcStructure); // 对象值

            return _structureMapper.FromRemoteValue<T>(value);  // 单值
        }

        public List<T> GetList<T>(string name)
        {
            var table = _function.GetTable(name);
            var returnTable = new List<T>(table.RowCount);
            for (int i = 0; i < table.RowCount; i++)
                returnTable.Add(_structureMapper.FromStructure<T>(table[i]));

            return returnTable;
        }
    }
}
