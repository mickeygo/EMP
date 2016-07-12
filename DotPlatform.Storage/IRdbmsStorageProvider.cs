using System.Data;

namespace DotPlatform.Storage
{
    /// <summary>
    /// 关系型数据储存提供者
    /// </summary>
    public interface IRdbmsStorageProvider
    {
        /// <summary>
        /// 获取 DB 连接<see cref="IDbConnection"/>
        /// </summary>
        IDbConnection Connection { get; }
    }
}
