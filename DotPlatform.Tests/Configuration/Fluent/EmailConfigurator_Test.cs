using DotPlatform.Configuration.Fluent;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotPlatform.Tests.Configuration.Fluent
{
    [TestClass]
    public class EmailConfigurator_Test
    {
        [TestMethod]
        public void ShouldGetEmailConfiguration_Test()
        {
            var configruator = new EmailFluentConfigurator();
            var emailConfig = configruator.GetConfiguration();

            var element = emailConfig.EmailElement;

            Assert.IsNotNull(element);
        }
    }
}
