using System.Collections.Generic;
using SAP.Middleware.Connector;
using DotPlatform.Plugin.SAP.Rfc.Exceptions;
using DotPlatform.Utils;

namespace DotPlatform.Plugin.SAP.Rfc
{
    /// <summary>
    /// Rfc Command 基类
    /// </summary>
    public abstract class RfcCommand : IRfcCommand
    {
        private readonly IRfcProvider _rfcProvider;

        protected RfcCommand(IRfcConnection connction)
        {
            _rfcProvider = connction.RfcProvider;
        }

        public virtual IRfcResult Execute(string functionName, object paramters = null)
        {
            var function = _rfcProvider.Rfc.Repository.CreateFunction(functionName);

            if (paramters != null)
                SetFunctionParamters(function, paramters);

            function.Invoke(_rfcProvider.Rfc);

            return null;
        }
        
        private void SetFunctionParamters(IRfcFunction function, object paramters)
        {
            var paramType = paramters.GetType();

            // IDictionary<,> 类型 或 匿名类型（匿名类型属于泛型）
            if (paramType.IsGenericType)
            {
                if (typeof(IDictionary<,>).IsAssignableFrom(paramType.GetGenericTypeDefinition()))
                {
                    var param = paramters as IDictionary<string, string>;
                    if (param != null)
                    {
                        foreach (var p in param)
                        {
                            function.SetValue(p.Key, p.Value);
                        }

                        return;
                    }

                    var param2 = paramters as IDictionary<string, object>;
                    if (param2 != null)
                    {
                        foreach (var p in param2)
                        {
                            function.SetValue(p.Key, p.Value);
                        }

                        return;
                    }

                    throw new RfcFunctionParamtersException("The function paramters must be an IDictionary or an Anonymous object.");
                }

                // 匿名类型
                foreach (var param in ReflectionHelper.GetNameValues(paramters))
                {
                    function.SetValue(param.Key, param.Value);
                }

                return;
            }

            throw new RfcFunctionParamtersException("The function paramters must be an IDictionary or an Anonymous object.");
        }
    }
}
