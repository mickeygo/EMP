namespace DotPlatform.Zero.Authorization.Users
{
    /// <summary>
    /// 用户管理
    /// </summary>
    public class UserManager
    {
        private readonly IUserStore _userStore;

        public UserManager(IUserStore userStore)
        {
            _userStore = userStore;
        }
    }
}
