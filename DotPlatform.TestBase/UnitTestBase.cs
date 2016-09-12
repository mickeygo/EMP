using DotPlatform.Reflection;

namespace DotPlatform.TestBase
{
    /// <summary>
    /// 单元测试基类
    /// </summary>
    public abstract class UnitTestBase
    {
        protected UnitTestBase()
        {
            PreInitialize();
            InitIocContainer();
            PostInitialize();
        }

        protected virtual void PreInitialize()
        {
            AssemblyLoadHelper.LoadAssembly("WMS");
        }

        protected virtual void PostInitialize()
        {

        }

        private void InitIocContainer()
        {
            var bootstrapper = new Bootstrapper();
            bootstrapper.PreInitializeEvent += (o, s) => PreInitialize();
            bootstrapper.PostInitializeEvent += (o, s) => PostInitialize();

            bootstrapper.OnInitialize();
        }
    }
}
