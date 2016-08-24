namespace DotPlatform.Authorization
{
    /// <summary>
    /// 表示实现此接口的类表示权限定义的上下文。
    /// 上下文中用来创建和获取权限
    /// </summary>
    public interface IPermissionDefinitionContext
    {
        /// <summary>
        /// 创建权限
        /// </summary>
        /// <param name="name">权限名</param>
        /// <param name="displayName">权限显示名</param>
        /// <param name="isGrantedByDefault">是否授权</param>
        /// <param name="description">权限描述</param>
        /// <returns></returns>
        Permission CreatePermission(
            string name,
            string displayName = null,
            bool isGrantedByDefault = false,
            string description = null
            );

        /// <summary>
        /// 获取指定名称的权限。若不存在则返回 null
        /// </summary>
        /// <param name="name">权限名</param>
        /// <returns></returns>
        Permission GetPermissionOrNull(string name);
    }
}
