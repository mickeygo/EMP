using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WMS.Web.Client
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

        public static IHtmlString Navgation2(this HtmlHelper helper, params string[] navgations)
        {
            var navs = navgations != null
             ? navgations.ToDictionary(k => k, v => "")
             : new Dictionary<string, string>();
            return CreateNavgation2(helper, "Home", navs);
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

        public static IHtmlString Navgation2(this HtmlHelper helper, Dictionary<string, string> navgations)
        {
            return CreateNavgation2(helper, "Home", navgations);
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

        private static IHtmlString CreateNavgation2(this HtmlHelper helper, string home, Dictionary<string, string> navgations)
        {
            //<ul class="page-breadcrumb breadcrumb">
            //    <li>
            //        <a href="index.html">Home</a>
            //        <i class="fa fa-circle"></i>
            //    </li>
            //    <li>
            //        <a href="#">Tables</a>
            //        <i class="fa fa-circle"></i>
            //    </li>
            //    <li>
            //        <span class="active">Dashboard</span>
            //    </li>
            //</ul>

            var itemBuilder = new StringBuilder();
            itemBuilder.Append(CreateHomeNav(home));

            var navIndex = 0;
            foreach (var navgation in navgations)
            {
                var barTag = new TagBuilder("i");
                barTag.AddCssClass("fa fa-circle");

                TagBuilder valTag;
                if (++navIndex < navgations.Count)
                {
                    valTag = new TagBuilder("a");
                    valTag.MergeAttribute("href", string.IsNullOrWhiteSpace(navgation.Value) ? "javascript:void(0)" : navgation.Value);
                    valTag.SetInnerText(navgation.Key);
                }
                else
                {
                    valTag = new TagBuilder("span");
                    valTag.AddCssClass("active");
                    valTag.SetInnerText(navgation.Key);
                }

                var liTag = new TagBuilder("li");
                liTag.InnerHtml = barTag.ToString() + valTag.ToString();

                itemBuilder.Append(liTag.ToString());
            }

            var ulTag = new TagBuilder("ul");
            ulTag.AddCssClass("page-breadcrumb breadcrumb");
            ulTag.InnerHtml = itemBuilder.ToString();

            var menuTag = new TagBuilder("div");
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
