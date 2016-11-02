using System.Linq;
using System.Text;
using DotPlatform.RBAC.Domain.Models.Users;
using DotPlatform.Storage;
using DotPlatform.Storage.Rdbms;
using DotPlatform.RBAC.Domain.Models.Tenants;
using DotPlatform.RBAC.Domain.QueryRepositories;

namespace DotPlatform.RBAC.Repository.ADO
{
    /// <summary>
    /// 用户存储
    /// </summary>
    public class UserStorage : RbacStorage, IUserQueryStorage
    {
        public UserStorage(IRdbmsStorageProvider provider) : base(provider)
        {
        }

        public RbacUser GetUser(string userName)
        {
            var sqlQuery = new StringBuilder();
            sqlQuery.AppendLine(" SELECT UserId AS Id, UserName, Password, EmailAddress, EmployeeNo, EnglishName, LocalName, Organization, Department ");
            sqlQuery.AppendLine("       ,Job, Tel, Extension, RBAC_User.TenantId, RBAC_User.IsDeleted, LastLoginTime ");
            sqlQuery.AppendLine("       ,tenant.TenantId AS Id, tenant.Name, tenant.DisplayName, tenant.Description ");
            sqlQuery.AppendLine("       ,tenant.TimeDifference, tenant.Language, tenant.IsActive, tenant.IsDeleted ");
            sqlQuery.AppendLine(" FROM	RBAC_User ");
            sqlQuery.AppendLine("       LEFT JOIN dbo.RBAC_Tenant tenant ON tenant.TenantId = RBAC_User.TenantId AND tenant.IsDeleted = 0 ");
            sqlQuery.AppendLine(" WHERE	dbo.RBAC_User.IsDeleted = 0 ");
            sqlQuery.AppendLine("       AND RBAC_User.UserName = @UserName ");

            return this.Select(sqlQuery.ToString(), (RbacUser user, RbacTenant tenant) =>
            {
                user.BindTenant(tenant);
                return user;

            }, new { UserName = userName }).FirstOrDefault();
        }
    }
}
