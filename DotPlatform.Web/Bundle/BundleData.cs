using System.Collections.Generic;

namespace DotPlatform.Web.Bundle
{
    /// <summary>
    /// 文件压缩数据
    /// </summary>
    public class BundleData
    {
        /// <summary>
        /// 压缩的内容
        /// </summary>
        public List<BundleContent> Bundles { get; set; }
    }
}
