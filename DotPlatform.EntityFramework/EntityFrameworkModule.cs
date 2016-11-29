using DotPlatform.Domain.Uow;
using DotPlatform.EntityFramework.Uow;
using DotPlatform.Modules;

namespace DotPlatform.EntityFramework
{
    /// <summary>
    /// DotPlatform 系统 EntityFramework 模块依赖对象
    /// </summary>
    [DependsOn]
    public class EntityFrameworkModule : ModuleBase
    {
        public override void PreInitialize()
        {
            IocManager.RegisterGeneric(typeof(IDbContextProvider<>), typeof(UnitOfWorkDbContextProvider<>));
            IocManager.RegisterGeneric(typeof(ISimpleDbContextProvider<>), typeof(SimpleDbContextProvider<>));
            IocManager.Register<IUnitOfWork, EfUnitOfWork>();

            base.PreInitialize();
        }
    }
}
