using DotPlatform.Dependency;
using DotPlatform.Net.Mail;
using DotPlatform.Net.Mail.Smtp;
using DotPlatform.TestBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotPlatform.Tests.Net.Mail
{
    [TestClass]
    public class Mail_Tests : UnitTestBase
    {
        [TestMethod]
        public void Should_Send_Mail_Test()
        {
            var mailConfig = new SmtpMailSenderConfiguration();
            var mailSender = new SmtpMailSender(mailConfig);

            mailSender.Send(new string[] { "gang.yang@advantech.com.cn" }, null, null, "DotPlatform Test", "DotPlatform Test Body", (string[])null);
        }

        [TestMethod]
        public void Should_Send_Mail_Test2()
        {
            var mailSender = IocManager.Instance.Resolve<IMailSender>();

            mailSender.Send(new string[] { "gang.yang@advantech.com.cn" }, null, null, "DotPlatform Test", "DotPlatform Test Body", (string[])null);
            mailSender.Send(new string[] { "gang.yang@advantech.com.cn" }, null, null, "DotPlatform Test 2", "DotPlatform Test Body 2", (string[])null);
        }
    }
}
