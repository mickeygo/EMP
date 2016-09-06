using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Web.Mvc
{
    /// <summary>
    /// Html 导航标签
    /// </summary>
    public static class HtmlNavgationExtensions
    {
        /// <summary>
        /// 导航标签
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="navgations">导航值</param>
        /// <returns></returns>
        public static IHtmlString Navgation(this HtmlHelper helper, params string[] navgations)
        {
            var navs = navgations != null
             ? navgations.ToDictionary(k => k, v => "")
             : new Dictionary<string, string>();
            return CreateNavgation(helper, "Home", navs);
        }

        /// <summary>
        /// 导航标签
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="navgations">导航值</param>
        /// <returns></returns>
        public static IHtmlString Navgation(this HtmlHelper helper, Dictionary<string, string> navgations)
        {
            return CreateNavgation(helper, "Home", navgations);
        }

        private static IHtmlString CreateNavgation(this HtmlHelper helper, string home, Dictionary<string, string> navgations)
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
                TagBuilder valTag = new TagBuilder("a");
                valTag.MergeAttribute("href", string.IsNullOrWhiteSpace(navgation.Value) ? "javascript:void(0)" : navgation.Value);
                valTag.SetInnerText(navgation.Key);

                TagBuilder liTag = new TagBuilder("li");
                liTag.InnerHtml = valTag.ToString();

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
