using DotPlatform.Application.Services;
using DotPlatform.Zero.Client.Dto;

namespace DotPlatform.Zero.Client.AppServices
{
    /// <summary>
    /// 实现此接口的类为用户应用服务接口
    /// </summary>
    public interface IUserAppService : IApplicationService
    {
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="input">用户 Dto 对象</param>
        void CreateUser(UserDto input);
    }
}
