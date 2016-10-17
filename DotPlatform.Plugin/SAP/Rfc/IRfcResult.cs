using System.Collections.Generic;

namespace DotPlatform.Plugin.SAP.Rfc
{
    /// <summary>
    /// Rfc 输出结果
    /// </summary>
    public interface IRfcResult
    {
        /// <summary>
        /// 获取输出结果
        /// </summary>
        /// <typeparam name="T">结果类型</typeparam>
        /// <param name="name">值名称</param>
        /// <returns></returns>
        T Get<T>(string name);

        /// <summary>
        /// 获取输出结果，以集合的形式输出
        /// </summary>
        /// <typeparam name="T">结果类型</typeparam>
        /// <param name="name">值名称</param>
        /// <returns></returns>
        IEnumerable<T> GetList<T>(string name);
    }
}
