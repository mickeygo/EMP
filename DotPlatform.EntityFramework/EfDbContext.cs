using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Threading;
using System.Threading.Tasks;
using EntityFramework.DynamicFilters;
using DotPlatform.Runtime.Session;
using DotPlatform.Domain;
using DotPlatform.Domain.Entities;
using DotPlatform.Domain.Entities.Auditing;
using DotPlatform.Domain.Entities.Extensions;

namespace DotPlatform.EntityFramework
{
    /// <summary>
    /// 基于 Microsoft EntityFramework 的 <see cref="DbContext"/> 的基类。
    /// 对<see cref="DbContext"/>进行了扩展，派生类用于<see cref="EfRepository"/>仓储。
    /// </summary>
    public abstract class EfDbContext : DbContext
    {
        #region Propertites

        /// <summary>
        /// 获取或设置当前会话信息
        /// </summary>
        public IOwnerSession OwnerSession { get; protected set; }

        /// <summary>
        /// 是否启用多租户, 默认为 true.
        /// </summary>
        public bool EnableMultiTenant { get; protected set; } = true;

        #endregion

        #region Ctor

        /// <summary>
        /// 初始化一个新的<see cref="EfDbContext"/>实例
        /// </summary>
        protected EfDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Initialize();
        }

        /// <summary>
        /// 初始化一个新的<see cref="EfDbContext"/>实例
        /// </summary>
        protected EfDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
            Initialize();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 重写 <see cref="DbContext"/> 的 SaveChanges 方法
        /// </summary>
        public override int SaveChanges()
        {
            this.ApplyConcepts();
            return base.SaveChanges();
        }

        /// <summary>
        /// 重写 <see cref="DbContext"/> 的 SaveChangesAsync 方法
        /// </summary>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            this.ApplyConcepts();
            return await base.SaveChangesAsync(cancellationToken);
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// 可以重写， 通过 Fluent API 方式配置实体模型
        /// </summary>
        protected virtual void CreateModel(DbModelBuilder modelBuilder)
        {

        }

        /// <summary>
        /// 重写 <see cref="DbContext"/> 的 OnModelCreating 方法。
        /// 默认情况下，为了性能，此方法只会调用一次，然后会被缓存起来。
        /// </summary>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fluent API Entity
            this.CreateModel(modelBuilder);

            // Filter
            modelBuilder.Filter(EntityDataFilters.SoftDelete, (ISoftDelete d) => d.IsDeleted, false);

            // Enabled tenant filter
            if (EnableMultiTenant)
            {
                modelBuilder.Filter(EntityDataFilters.MustHaveTenant, (IMustHaveTenant t, Guid tenantId) => t.TenantId == tenantId, Guid.Empty);
                modelBuilder.Filter(EntityDataFilters.MayHaveTenant, (IMayHaveTenant t, Guid? tenantId) => t.TenantId == tenantId, Guid.Empty);
            }
        }

        /// <summary>
        /// 在调用 SaveChanges / SaveChangesAsync 之前，会先调用此方法
        /// </summary>
        protected virtual void ApplyConcepts()
        {
            foreach (var entry in this.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        this.ApplyAddedConcepts(entry);
                        break;
                    case EntityState.Modified:
                        this.ApplyModifiedConcepts(entry);
                        break;
                    case EntityState.Deleted:
                        this.ApplyDeletedConcepts(entry);
                        break;
                }
            }
        }

        /// <summary>
        /// 检查实体主键，实体主键类型为<see cref="Guid"/>时，若不存在则设置主键.
        /// </summary>
        protected virtual void CheckOrSetEntityKeyIfNull(DbEntityEntry entry)
        {
            if (entry.Entity is IEntity)
                ((IEntity)entry.Entity).CheckOrSetEntityKeyIfNull();
        }

        /// <summary>
        /// 设置实体的创建审计信息（创建者和创建时间）
        /// </summary>
        protected virtual void SetCreationAuditProperties(DbEntityEntry entry)
        {
            if (entry.Entity is IHasCreationTime)
                entry.Cast<IHasCreationTime>().Entity.SetCreationTimeAuditProperty();

            if (entry.Entity is ICreationAudited)
                entry.Cast<ICreationAudited>().Entity.SeCreationAuditProperty(this.OwnerSession);
        }

        /// <summary>
        /// 设置实体的修改审计信息（修改者和修改时间）
        /// </summary>
        protected virtual void SetModificationAuditProperties(DbEntityEntry entry)
        {
            if (entry.Entity is IHasModificationTime)
                entry.Cast<IHasModificationTime>().Entity.SetModificationTimeAuditProperty();

            if (entry.Entity is IModificationAudited)
                entry.Cast<IModificationAudited>().Entity.SetModificationAuditProperty(this.OwnerSession);
        }

        /// <summary>
        /// 设置实体的删除审计信息（删除者和删除时间）
        /// </summary>
        protected virtual void SetDeletionAuditProperties(DbEntityEntry entry)
        {
            if (entry.Entity is IHasDeletionTime)
                entry.Cast<IHasDeletionTime>().Entity.SetDeletionTimeAuditProperty();

            if (entry.Entity is IDeletionAudited)
                entry.Cast<IDeletionAudited>().Entity.SetDeletionAuditProperty(this.OwnerSession);
        }

        /// <summary>
        /// 处理软删除. 若实体实现了 <see cref="ISoftDelete"/> 接口，删除时会将 IsDeleted 设为 true.
        /// </summary>
        protected virtual void HandleSoftDelete(DbEntityEntry entry)
        {
            if (!(entry.Entity is ISoftDelete))
                return;

            var softEntity = entry.Cast<ISoftDelete>();
            softEntity.State = EntityState.Unchanged;
            softEntity.Entity.SetDeleted();

            this.SetDeletionAuditProperties(entry);
        }

        /// <summary>
        /// 检查实体的必须存在的租户信息
        /// </summary>
        protected virtual void CheckOrSetMustHaveTenantIfNull(DbEntityEntry entry)
        {
            var entity = entry.Cast<IMustHaveTenant>().Entity;

            // 租户未启用
            if (!this.IsFilterEnabled(EntityDataFilters.MustHaveTenant))
            {
                if (OwnerSession.TenantId.HasValue && entity.TenantId != Guid.Empty)
                    entity.TenantId = OwnerSession.TenantId.Value;

                return;
            }

            // Filter Enabled
            var currentTenantId = (Guid)this.GetFilterParameterValue(EntityDataFilters.MustHaveTenant, EntityDataFilters.Parameters.TenantId);
            if (currentTenantId == Guid.Empty)
            {
                throw new DbEntityValidationException(
                    "Can not save a IMustHaveTenant entity while MustHaveTenant filter is enabled and current filter parameter value is not set (Probably, no tenant user logged in)!");
            }

            if (entity.TenantId == Guid.Empty)
            {
                entity.TenantId = currentTenantId;
            }
            else if (entity.TenantId != currentTenantId && entity.TenantId != OwnerSession.TenantId)
            {
                throw new DbEntityValidationException(
                    "Can not set IMustHaveTenant.TenantId to a different value than the current filter parameter value or IOwnerSession.TenantId while MustHaveTenant filter is enabled!");
            }
        }

        /// <summary>
        /// 检查实体的可能存在的租户信息
        /// </summary>
        protected virtual void CheckOrSetMayHaveTenantIfNull(DbEntityEntry entry)
        {
            // 租户未启用，直接退出函数
            if (!this.IsFilterEnabled(EntityDataFilters.MayHaveTenant))
                return;

            // Filter Enabled
            var currentTenantId = (Guid?) this.GetFilterParameterValue(EntityDataFilters.MayHaveTenant, EntityDataFilters.Parameters.TenantId);

            var entity = entry.Cast<IMayHaveTenant>().Entity;

            if (entity.TenantId != currentTenantId && entity.TenantId != OwnerSession.TenantId)
            {
                throw new DbEntityValidationException(
                    "Can not set TenantId to a different value than the current filter parameter value or IOwnerSession.TenantId while MayHaveTenant filter is enabled!");
            }
        }

        #endregion

        #region Private Methods

        private void ApplyAddedConcepts(DbEntityEntry entry)
        {
            CheckOrSetEntityKeyIfNull(entry);
            SetCreationAuditProperties(entry);
            CheckOrSetTenantIfNull(entry);
        }

        private void ApplyModifiedConcepts(DbEntityEntry entry)
        {
            CheckOrSetTenantIfNull(entry);
            SetModificationAuditProperties(entry);
        }

        private void ApplyDeletedConcepts(DbEntityEntry entry)
        {
            HandleSoftDelete(entry);
        }

        private void CheckOrSetTenantIfNull(DbEntityEntry entry)
        {
            if (entry.Entity is IMustHaveTenant)
            {
                this.CheckOrSetMustHaveTenantIfNull(entry);
            }
            else if (entry.Entity is IMayHaveTenant)
            {
                this.CheckOrSetMayHaveTenantIfNull(entry);
            }
        }

        #endregion

        #region Initialize

        /// <summary>
        /// 对象实例化后自动调用该初始化方法
        /// </summary>
        protected virtual void Initialize()
        {
            //Database.Initialize(false);
            //Database.SetInitializer<MyDbContext>(null);

            OwnerSession = ClaimsSession.Instance;

            // 设置筛选参数，在筛选时(Filter)筛选器会使用相应的设置的参数名进行匹配
            this.SetFilterScopedParameterValue(EntityDataFilters.MustHaveTenant, EntityDataFilters.Parameters.TenantId, OwnerSession.TenantId ?? Guid.Empty);
            this.SetFilterScopedParameterValue(EntityDataFilters.MayHaveTenant, EntityDataFilters.Parameters.TenantId, OwnerSession.TenantId);
        }

        #endregion
    }
}
