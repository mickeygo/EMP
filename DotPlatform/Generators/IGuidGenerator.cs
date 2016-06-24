using System;

namespace DotPlatform.Generators
{
    /// <summary>
    /// 表示实现接口的类为 GUID 生成器
    /// </summary>
    public interface IGuidGenerator
    {
        /// <summary>
        /// 创建一个新的 GUID
        /// </summary>
        /// <returns></returns>
        Guid Create();
    }
}
