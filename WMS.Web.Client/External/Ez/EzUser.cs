using DotPlatform.Dependency;
using WMS.DataTransferObject.Dtos;

namespace WMS.Web.Client.External.Ez
{
    /// <summary>
    /// EZ 系统 User
    /// </summary>
    public class EzUser
    {
        public UserDto FindUser(string userName)
        {
            var proxy = IocManager.Instance.Resolve<EzUserRepository>();
            return proxy.FindUser(userName);
        }
    }
}
