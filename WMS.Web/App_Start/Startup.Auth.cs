using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;

namespace WMS.Web
{
	public partial class Startup
	{
		/// <summary>
		/// 配置基于 Cookie 的验证信息
		/// </summary>
		public void ConfigureCookieAuth(IAppBuilder app)
		{
			app.UseCookieAuthentication(new CookieAuthenticationOptions
			{
				AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
				LoginPath = new PathString("/Account/Login"),
				LogoutPath = new PathString("/Account/Logout")
			});
		}
	}
}
