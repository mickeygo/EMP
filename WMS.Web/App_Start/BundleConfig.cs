using System.Web.Optimization;
using System.Runtime.CompilerServices;
using DotPlatform.Extensions;
using DotPlatform.Web.Bundle;
using System.Web.Optimization.React;

namespace WMS.Web
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
            RegisterBundlesFromConfigFile(bundles);

            bundles.Add(new BabelBundle("~/bundles/script/src")
                .IncludeDirectory("~/wwwroot/js/src/", "*.js", false)
                .IncludeDirectory("~/wwwroot/js/src/", "*.jsx", false));
        }

        #region Metronic UI

        // Core
        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void RegisterBundlesFromConfigFile(BundleCollection bundles)
        {
            var manager = new BundleManager();
            var bundleData = manager.Resolve();

             if (bundleData == null || bundleData.Bundles.IsNullOrEmpty())
                return;

            foreach (var bundle in bundleData.Bundles)
            {
                Bundle mBundle = null;
                if (bundle.Type == "script")
                    mBundle = new ScriptBundle(bundle.VirtualPath);
                else if (bundle.Type == "style")
                    mBundle = new StyleBundle(bundle.VirtualPath);

                if (mBundle == null)
                    continue;

                if(!bundle.VirtualFilePaths.IsNullOrEmpty())
                    mBundle.Include(bundle.VirtualFilePaths);

                if (!bundle.Directories.IsNullOrEmpty())
                {
                    foreach (var dir in bundle.Directories)
                    {
                        mBundle.IncludeDirectory(dir.DirectoryVirtualPath, dir.SearchPattern, dir.SearchSubdirectories);
                    }
                }

                bundles.Add(mBundle);
            }
        }

        // Plugins

        #endregion
    }
}
