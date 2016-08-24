using System.Linq;
using Castle.DynamicProxy;

namespace DotPlatform.Bus
{
    /// <summary>
    /// 用于 Bus 的拦截器
    /// </summary>
    public class BusInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var busAttrs = invocation.MethodInvocationTarget.GetCustomAttributes(typeof(BusAttribute), false);

            if (busAttrs == null || !busAttrs.Any())
            {
                // Todo:
            }
            
            invocation.Proceed();
        }
    }
}
