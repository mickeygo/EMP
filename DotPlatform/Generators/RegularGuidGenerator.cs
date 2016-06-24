using System;

namespace DotPlatform.Generators
{
    /// <summary>
    /// 表示是常规的 GUID 生成器
    /// </summary>
    public class RegularGuidGenerator : IGuidGenerator
    {
        public Guid Create()
        {
            return Guid.NewGuid();
        }
    }
}
