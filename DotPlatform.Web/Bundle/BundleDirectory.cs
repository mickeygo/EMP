namespace DotPlatform.Web.Bundle
{
    /// <summary>
    /// Bundle 文件目录
    /// </summary>
    public class BundleDirectory
    {
        /// <summary>
        /// 文件虚拟目录
        /// </summary>
        public string DirectoryVirtualPath { get; set; }

        /// <summary>
        /// 搜索文件的匹配模式
        /// </summary>
        public string SearchPattern { get; set; }

        /// <summary>
        /// 是否要搜索目录
        /// </summary>
        public bool SearchSubdirectories { get; set; }
    }
}
