using System;
using System.Linq;
using System.Collections.Generic;

namespace DotPlatform.Modules
{
    /// <summary>
    /// 模块管理
    /// </summary>
    public class ModuleManager : IModuleManager
    {
        private readonly IModuleFinder _moduleFinder;
        private List<ModuleBase> _modules;

        public ModuleManager(IModuleFinder moduleFinder)
        {
            _moduleFinder = moduleFinder;
        }

        public void Initialize()
        {
            // Load all modules
            _modules = LoadAllModules();

            // Execute loaded module PreInitialize, Initialize an PostInitialize function
            _modules.ForEach(m =>
            {
                m.PreInitialize();
                m.Initialize();
                m.PostInitialize();
            });
        }

        public void Shutdown()
        {
            if (_modules != null)
            {
                _modules.ForEach(m =>
                {
                    m.Shutdown();
                });
            }
        }

        #region Private Methods

        // 加载所有的模块
        private List<ModuleBase> LoadAllModules()
        {
            var moduleTypes = _moduleFinder.FindAll();
            return moduleTypes.Select(m => Activator.CreateInstance(m)).Cast<ModuleBase>().ToList();
        }

        #endregion
    }
}
