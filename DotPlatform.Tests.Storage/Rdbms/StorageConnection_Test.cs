using DotPlatform.Dependency;
using DotPlatform.TestBase;
using DotPlatform.TestBase.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotPlatform.Tests.Storage.Rdbms
{
    [TestClass]
    public class StorageConnection_Test : UnitTestBase
    {
        protected override void PreInitialize()
        {
            IocManager.Instance.Register<MyTestRepository>();
        }

        [TestMethod]
        public void ConnectionState_Test()
        {
            var sqlQuery = " SELECT ProductId AS Id, Name, Model, IsDeleted, CreatorUserId, CreationTime ";
            sqlQuery += "   ,LastModifierUserId, LastModificationTime, DeleterUserId, DeletionTime ";
            sqlQuery += "   FROM dbo.Product ";

            var repository = IocManager.Instance.Resolve<MyTestRepository>();
            Assert.IsNotNull(repository);

            var product = repository.Select<Product>(sqlQuery);

            using (repository.Connection)
            {
                Assert.IsTrue(repository.Connection.State == System.Data.ConnectionState.Closed);
            }
        }

        [TestMethod]
        public void ConnectionStateDataReader_Test()
        {
            var sqlQuery = " SELECT ProductId AS Id, Name, Model, IsDeleted, CreatorUserId, CreationTime ";
            sqlQuery += "   ,LastModifierUserId, LastModificationTime, DeleterUserId, DeletionTime ";
            sqlQuery += "   FROM dbo.Product ";

            var repository = IocManager.Instance.Resolve<MyTestRepository>();
            Assert.IsNotNull(repository);

            var dr = repository.ExecuteReader(sqlQuery);
            dr.Dispose();

            using (repository.Connection)
            {
                Assert.IsTrue(repository.Connection.State == System.Data.ConnectionState.Closed);
            }
        }
    }
}
