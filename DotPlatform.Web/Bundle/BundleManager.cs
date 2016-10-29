using System;
using System.IO;
using System.Text;
using DotPlatform.Serialization.Json;

namespace DotPlatform.Web.Bundle
{
    /// <summary>
    /// 压缩文件管理者
    /// </summary>
    public class BundleManager
    {
        /// <summary>
        /// 压缩的文件名
        /// </summary>
        public const string BundleConfigFile = "bundle.config.json";

        /// <summary>
        /// 解析压缩的文件
        /// </summary>
        /// <returns></returns>
        public BundleData Resolve()
        {
            var filePath = GetBundleConfigFilePath();

            if (!File.Exists(filePath))
                return null;

            string json;
            using (var reader = new StreamReader(filePath, Encoding.UTF8, true))
            {
                json = reader.ReadToEnd();
            }

            return JsonSerializationHelper.Deserialize<BundleData>(json);
        }

        private string GetBundleConfigFilePath()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(baseDir, BundleConfigFile);
        }
    }
}
