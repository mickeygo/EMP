namespace DotPlatform.Zero.Authorization.Roles
{
    /// <summary>
    /// 角色管理
    /// </summary>
    public class RoleManager
    {
        private readonly IRoleStore _roleStore;

        public RoleManager(IRoleStore roleStore)
        {
            _roleStore = roleStore;
        }
    }
}
