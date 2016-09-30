namespace DotPlatform.Plugin.SAP.Rfc
{
    /// <summary>
    /// Rfc 命令接口
    /// </summary>
    public interface IRfcCommand
    {
        /// <summary>
        /// 执行函数
        /// </summary>
        /// <param name="functionName">函数名称</param>
        /// <param name="paramters">参数</param>
        IRfcResult Execute(string functionName, object paramters = null);
    }
}
