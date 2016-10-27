using System.Collections.Generic;
using SAP.Middleware.Connector;
using DotPlatform.Plugin.SAP.Rfc.Exceptions;
using DotPlatform.Utils;
using DotPlatform.Plugin.SAP.Rfc.Extensions;

namespace DotPlatform.Plugin.SAP.Rfc
{
    /// <summary>
    /// Rfc Command 基类
    /// </summary>
    public abstract class RfcCommand : IRfcCommand
    {
        private readonly IRfcProvider _rfcProvider;

        /// <summary>
        /// 结构映射器
        /// </summary>
        public RfcStructureMapper StructureMapper { get; protected set; }

        protected RfcCommand(IRfcConnection connction)
        {
            _rfcProvider = connction.RfcProvider;
        }

        protected abstract IRfcResult ReturnResult(IRfcFunction function);

        public IRfcResult Execute(string functionName, object paramters = null)
        {
            var function = _rfcProvider.Rfc.Repository.CreateFunction(functionName);

            if (paramters != null)
                SetFunctionParamters(function, paramters);

            function.Invoke(_rfcProvider.Rfc);

            return ReturnResult(function);
        }

        #region Private Methods

        private void SetFunctionParamters(IRfcFunction function, object parameters)
        {
            var paramType = parameters.GetType();

            // IDictionary<,> 类型 或 匿名类型（匿名类型属于泛型）
            if (paramType.IsGenericType)
            {
                if (typeof(IDictionary<,>).IsAssignableFrom(paramType.GetGenericTypeDefinition()))
                {
                    if (parameters is IDictionary<string, string>)
                    {
                        var param = parameters as IDictionary<string, string>;
                        SetFunctionValue(function, (IDictionary<string, object>)param);
                        return;
                    }

                    if (parameters is IDictionary<string, object>)
                    {
                        var param = parameters as IDictionary<string, object>;
                        SetFunctionValue(function, param);
                        return;
                    }

                    throw new RfcFunctionParamtersException("The function parameters must be an IDictionary or an anonymous object.");
                }

                // 匿名类型
                var m_parameters = ReflectionHelper.GetNameValues(parameters);
                SetFunctionValue(function, m_parameters);

                return;
            }

            throw new RfcFunctionParamtersException("The function paramters must be an IDictionary or an anonymous object.");
        }

        private void SetFunctionValue(IRfcFunction function, IDictionary<string, object> parameters)
        {
            foreach (var parameter in parameters)
            {
                var index = function.Metadata.TryNameToIndex(parameter.Key);
                if (index == -1)
                    throw new UnknownRfcParameterException($"The Rfc function does not include the parameter '{parameter.Key}'");

                var pType = function.Metadata[index].DataType;

                switch (pType)
                {
                    case RfcDataType.STRUCTURE:
                        RfcStructureMetadata structureMetadata = function.GetStructure(index).Metadata;
                        IRfcStructure structure = StructureMapper.CreateStructure(structureMetadata, parameter.Value);
                        function.SetValue(parameter.Key, structure);
                        break;
                    case RfcDataType.TABLE:
                        RfcTableMetadata tableMetadata = function.GetTable(index).Metadata;
                        IRfcTable table = StructureMapper.CreateTable(tableMetadata, parameter.Value);
                        function.SetValue(parameter.Key, table);
                        break;
                    default:
                        object formattedValue = StructureMapper.ToRemoteValue(function.Metadata[index].GetAbapDataType(), parameter.Value);
                        function.SetValue(parameter.Key, formattedValue);
                        break;
                }
            }
        }

        #endregion
    }
}
