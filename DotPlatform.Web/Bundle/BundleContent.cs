using System.Collections.Generic;

namespace DotPlatform.Web.Bundle
{
    /// <summary>
    /// 压缩的内容
    /// </summary>
    public class BundleContent
    {
        /// <summary>
        /// 压缩类型，分为 script 和 style
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 压缩后的虚拟目录
        /// </summary>
        public string VirtualPath { get; set; }

        /// <summary>
        /// 文件的虚拟路径集合
        /// </summary>
        public string[] VirtualFilePaths { get; set; }

        /// <summary>
        /// 文件目录集合
        /// </summary>
        public List<BundleDirectory> Directories { get; set; }
    }
}
