using DotPlatform.Modules;
using DotPlatform.Storage.Rdbms;

namespace DotPlatform.Storage
{
    /// <summary>
    /// 存储模块依赖
    /// </summary>
    [DependsOn]
    public class StorageModule : ModuleBase
    {
        public override void PreInitialize()
        {
            IocManager.Register<IRdbmsStorageProvider, RdbmsStorageProvider>();

            base.PreInitialize();
        }
    }
}
