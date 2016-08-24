using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DotPlatform.Web.Extensions.HtmlHelperExtensions
{
    /// <summary>
    /// Html 页面导航扩展
    /// </summary>
    public static class HtmlNavgationExtensions
    {
        public static IHtmlString Navgation(this HtmlHelper helper, string home, params string[] navgations)
        {
            var navs = navgations != null
             ? navgations.ToDictionary(k => k, v => "#")
             : new Dictionary<string, string>();
            return Navgation(helper, home, navs);
        }

        public static IHtmlString Navgation(this HtmlHelper helper, string home, Dictionary<string, string> navgations)
        {
            //<div>
            //    <ul class="breadcrumb">
            //        <li>
            //            <a href = "#" > Home </ a >
            //        </ li >
            //        < li >
            //            < a href="#">Dashboard</a>
            //        </li>
            //    </ul>
            //</div>

            var itemBuilder = new StringBuilder();
            itemBuilder.Append(CreateHomeNav(home));

            foreach (var navgation in navgations)
            {
                TagBuilder aTag = new TagBuilder("a");
                aTag.MergeAttribute("href", navgation.Value);
                aTag.SetInnerText(navgation.Key);

                TagBuilder liTag = new TagBuilder("li");
                liTag.InnerHtml = aTag.ToString();

                itemBuilder.Append(liTag.ToString());
            }

            TagBuilder ulTag = new TagBuilder("ul");
            ulTag.AddCssClass("breadcrumb");
            ulTag.InnerHtml = itemBuilder.ToString();

            TagBuilder menuTag = new TagBuilder("div");
            menuTag.InnerHtml = ulTag.ToString();

            return MvcHtmlString.Create(menuTag.ToString());
        }

        private static string CreateHomeNav(string home)
        {
            var navUrl = UrlHelper.GenerateContentUrl("/", new HttpContextWrapper(HttpContext.Current));

            TagBuilder aTag = new TagBuilder("a");
            aTag.MergeAttribute("href", navUrl);
            aTag.SetInnerText(home);

            TagBuilder liTag = new TagBuilder("li");
            liTag.InnerHtml = aTag.ToString();

            return liTag.ToString();
        }
    }
}
