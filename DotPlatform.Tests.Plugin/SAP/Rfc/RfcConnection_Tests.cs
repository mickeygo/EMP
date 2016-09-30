using DotPlatform.Plugin.SAP.Rfc.Plain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotPlatform.Tests.Plugin.SAP.Rfc
{
    [TestClass]
    public class RfcConnection_Tests
    {
        [TestMethod]
        public void Connection_Test()
        {
            var conn = new PlainRfcConnection("NAME=Advantech;USER=it01.acl;PASSWD=kjhgfdsa;CLIENT=168;ASHOST=172.20.1.176;SYSNR=05;LANG=EN");

            var command = conn.CreateCommand();
            command.Execute("Z_CO_GETRMAOPEX", new { I_GJAHR = "2016", I_PERIO = "005" });
        }
    }
}
