using DotPlatform.Dependency;
using DotPlatform.Storage;

namespace DotPlatform.Tests.Storage.Rdbms
{
    /// <summary>
    /// Storage 工厂
    /// </summary>
    public static class StorageFactory
    {
        /// <summary>
        /// AppTest 数据存储
        /// </summary>
        public static IRdbmsStorage AppTest
        {
            get { return CreateStorage("appTest"); }
        }

        #region Private Methods

        private static IRdbmsStorage CreateStorage(string connectionName)
        {
            var storage = IocManager.Instance.Resolve<IRdbmsStorage>();
            storage.ConnectionName = connectionName;

            return storage;
        }

        #endregion
    }
}
