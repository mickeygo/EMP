﻿namespace DotPlatform.TestBase
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

        }

        protected virtual void PostInitialize()
        {

        }

        private void InitIocContainer()
        {
            var bootstrapper = new Bootstrapper();
            bootstrapper.OnPreInitialize();
            bootstrapper.OnInitialize();
            bootstrapper.OnPostInitialize();
        }
    }
}
