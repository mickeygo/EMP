using System;
using System.Reflection;
using System.Threading.Tasks;

namespace DotPlatform.Threading
{
    /// <summary>
    /// 异步方法的帮助类
    /// </summary>
    public static class AsyncHelper
    {
        /// <summary>
        /// 判断指定的方法是否是异步方法
        /// </summary>
        /// <param name="method">给定的方法</param>
        /// <returns></returns>
        public static bool IsAsyncMethod(MethodInfo method)
        {
            return (
                method.ReturnType == typeof(Task) ||
                (method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
                );
        }

        /// <summary>
        /// 异步执行相关的任务。
        /// </summary>
        /// <param name="actualReturnValue">实际的返回值</param>
        /// <param name="postAction">执行完后调用的委托</param>
        /// <param name="finalAction">可能出现的异常委托</param>
        /// <returns></returns>
        public static async Task AwaitTaskWithPostActionAndFinally(Task actualReturnValue, Func<Task> postAction, Action<Exception> finalAction)
        {
            Exception exception = null;

            try
            {
                await actualReturnValue;
                await postAction();
            }
            catch (Exception ex)
            {
                exception = ex;
                throw;
            }
            finally
            {
                finalAction(exception);
            }
        }

        public static async Task<T> AwaitTaskWithPostActionAndFinallyAndGetResult<T>(Task<T> actualReturnValue, Func<Task> postAction, Action<Exception> finalAction)
        {
            Exception exception = null;

            try
            {
                var result = await actualReturnValue;
                await postAction();
                return result;
            }
            catch (Exception ex)
            {
                exception = ex;
                throw;
            }
            finally
            {
                finalAction(exception);
            }
        }

        public static object CallAwaitTaskWithPostActionAndFinallyAndGetResult(Type taskReturnType, object actualReturnValue, Func<Task> action, Action<Exception> finalAction)
        {
            return typeof(AsyncHelper)
                .GetMethod("AwaitTaskWithPostActionAndFinallyAndGetResult", BindingFlags.Public | BindingFlags.Static)
                .MakeGenericMethod(taskReturnType)
                .Invoke(null, new object[] { actualReturnValue, action, finalAction });
        }

    }
}
