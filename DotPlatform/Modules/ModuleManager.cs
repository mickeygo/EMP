using DotPlatform.Dependency;

namespace DotPlatform.Modules
{
    /// <summary>
    /// 模块管理
    /// </summary>
    public class ModuleManager : IModuleManager
    {
        private readonly IIocManager _iocManager;
        private readonly IModuleFinder _moduleFinder;

        public ModuleManager(IIocManager iocManager, IModuleFinder moduleFinder)
        {
            _iocManager = iocManager;
            _moduleFinder = moduleFinder;
        }

        public void Initialize()
        {
            
        }

        #region Private Methods

        // 加载所有的模块
        private void LoadAllModules()
        {
            var moduleTypes = _moduleFinder.FindAll();
        }

        #endregion
    }
}
