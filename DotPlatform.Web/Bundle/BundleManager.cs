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
            var dirPath = AppDomain.CurrentDomain.BaseDirectory;

            // web app
            if (dirPath.IndexOf("\\bin", StringComparison.OrdinalIgnoreCase) == -1)
                return Path.Combine(dirPath, BundleConfigFile);

            // app
            while (true)
            {
                var dir = Directory.GetParent(dirPath);

                if (dir.FullName == dir.Root.FullName)
                    break;

                if (dirPath.EndsWith("\\bin", StringComparison.OrdinalIgnoreCase))
                {
                    dirPath = dir.FullName;
                    break;
                }

                dirPath = dir.FullName;
            }

            return Path.Combine(dirPath, BundleConfigFile);
        }
    }
}
