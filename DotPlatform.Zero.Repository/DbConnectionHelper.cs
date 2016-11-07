namespace DotPlatform.Zero.Repository
{
    /// <summary>
    /// DB 连接
    /// </summary>
    public static class DbConnectionHelper
    {
        /// <summary>
        /// 连接名。
        /// 在 Develop 模式下字符串名为 {name + "Debug"} 
        /// </summary>
        /// <param name="name">config 文件中连接字符名</param>
        /// <returns></returns>
        public static string ConnectionName(string name)
        {
            return GetRealConnectionName(name);
        }

        private static string GetRealConnectionName(string name)
        {
#if DEBUG
            return name + "Debug";
#else
            return name;
#endif
        }
    }
}
