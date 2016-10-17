using System.Globalization;
using System.Threading;

namespace DotPlatform.Plugin.SAP.Rfc.Plain
{
    /// <summary>
    /// 基于 Plain 的 APAB 与 .NET 单值映射对象
    /// </summary>
    public class PlainRfcValueMapper : RfcValueMapper
    {
        protected override NumberFormatInfo GetNumberFormat()
        {
            return Thread.CurrentThread.CurrentCulture.NumberFormat;
        }
    }
}
