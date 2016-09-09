using System.Web.Optimization;
using System.Web.Optimization.React;

namespace WMS
{
    /// <summary>
    /// Bundle 配置，用于打包并优化 js 和 css .
    /// </summary>
    public static class BundleConfig
    {
        /// <summary>
        /// 注册要打包的 Js 和 Css 文件
        /// </summary>
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Css
            bundles.Add(RegisterMainCss());     // Main
            bundles.Add(RegisterAddonCss());    // Addon
            bundles.Add(RegisterCustomCss());    // Custom

            // Js
            bundles.Add(RegisterMainJs());      // Main
            bundles.Add(RegisterAddonJs());     // Addon
            bundles.Add(RegisterCustomJs());    // Custom Js

            bundles.Add(RegisterSrcJsx());      // jsx
        }

        #region Private Methods

        // 主要 Css
        private static Bundle RegisterMainCss()
        {
            return new StyleBundle("~/content/main").Include(
                "~/Content/bootstrap.css");
        }

        // 插件 Css
        private static Bundle RegisterAddonCss()
        {
            return new StyleBundle("~/content/addon").Include(
                "~/Content/css/select2.css");
        }

        private static Bundle RegisterCustomCss()
        {
            return new StyleBundle("~/content/custom").Include(
                "~/Content/site.custom.css",
                "~/Content/component.custom.css");
        }

        // 主要 Js
        private static Bundle RegisterMainJs()
        {
            return new ScriptBundle("~/bundles/main").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js").Include(
                "~/Scripts/react/react.js",
                "~/Scripts/react/react-dom.js");
        }

        // 插件 Js
        private static Bundle RegisterAddonJs()
        {
            return new ScriptBundle("~/bundles/addon").Include(
                "~/Scripts/DataTables/jquery.dataTables.js",
                "~/Scripts/jquery.form.js",
                "~/Scripts/jquery.cookie.js",
                "~/Scripts/jquery.blockUI.js").Include(
                "~/Scripts/select2.js",
                "~/Scripts/jquery.maskedinput.js",
                "~/Scripts/noty/jquery.noty.js");
        }

        // 自定义脚本
        private static Bundle RegisterCustomJs()
        {
            return new ScriptBundle("~/bundles/custom")
                .IncludeDirectory("~/Js/utils", "*.js", false)
                .Include("~/Js/startup.js");
        }

        private static Bundle RegisterSrcJsx()
        {
            return new BabelBundle("~/bundles/src")
                 .IncludeDirectory("~/Js/src", "*.jsx", true);
        }
        
        #endregion
    }
}
