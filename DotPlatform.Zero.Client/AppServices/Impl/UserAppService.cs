using DotPlatform.Application.Services;
using DotPlatform.Zero.Client.Dto;
using DotPlatform.Zero.Domain.Models.Core;

namespace DotPlatform.Zero.Client.AppServices.Impl
{
    /// <summary>
    /// 用户应用服务
    /// </summary>
    internal class UserAppService : ApplicationService, IUserAppService
    {
        public UserAppService()
        {
            
        }

        public void CreateUser(UserDto input)
        {
            var user = new User(input.TenantId, input.UserName, input.Password, input.EmailAddress);

        }

        protected override void Close()
        {
            
        }
    }
}
