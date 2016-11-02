using DotPlatform.Storage;
using DotPlatform.Storage.Rdbms;

namespace DotPlatform.RBAC.Repository.ADO
{
    /// <summary>
    /// Rbac 存储基类
    /// </summary>
    public abstract class RbacStorage : DapperRdbmsStorage
    {
        public RbacStorage(IRdbmsStorageProvider provider) : base(LocalConnectionName, provider)
        {

        }


        #region

        /// <summary>
        /// 获取 DB 上下文连接字符串名称
        /// </summary>
        public static string LocalConnectionName
        {
            get { return GetRealConnectionName("RBAC"); }
        }

        #endregion

        #region Private Methods

        private static string GetRealConnectionName(string name)
        {
#if DEBUG
            return name + "Debug";
#else
            return name;
#endif
        }

        #endregion
    }
}
