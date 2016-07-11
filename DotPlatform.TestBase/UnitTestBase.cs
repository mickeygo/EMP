using DotPlatform;

namespace DotPlatform.TestBase
{
    public abstract class UnitTestBase
    {
        protected UnitTestBase()
        {
            InitIocContainer();
        }

        private void InitIocContainer()
        {
            new Bootstrapper().Initialize();
        }
    }
}
