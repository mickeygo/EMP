using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WMS.Web.Client.Remote.Sap;

namespace DotPlatform.Tests.SampleApplication.Clients
{
    [TestClass]
    public class SapRfc_Tests
    {
        [TestMethod]
        public void Shoud_Inhouse_posted_Test()
        {
            string docNo, errorMessage;
            SapClient.Post("201637-L-0066", "DSG8012PA", "CKB1", "98993505010", 12, "CKH2", "0000", true, DateTime.Now, out docNo, out errorMessage);
        }
    }
}
