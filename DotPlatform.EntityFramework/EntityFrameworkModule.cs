using DotPlatform.Dependency;
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
            IocManager.RegisterGeneric(typeof(IDbContextProvider<>), typeof(UnitOfWorkDbContextProvider<>), IocLifeStyle.Transient);
            IocManager.Register<IUnitOfWork, EfUnitOfWork>(IocLifeStyle.Transient);

            this.IocManager.Build();
        }
    }
}
