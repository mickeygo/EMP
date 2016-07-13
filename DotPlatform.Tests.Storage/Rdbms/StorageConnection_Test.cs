using DotPlatform.Storage.Rdbms;
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
            var dic = RdbmsStorageHelper.StorageDictionary;
        }

        [TestMethod]
        public void ConnectionState_Test()
        {
            var sqlQuery = " SELECT ProductId AS Id, Name, Model, IsDeleted, CreatorUserId, CreationTime ";
            sqlQuery += "   ,LastModifierUserId, LastModificationTime, DeleterUserId, DeletionTime ";
            sqlQuery += "   FROM dbo.Product ";

            var storage = StorageFactory.AppTest;
            var product = storage.Select<Product>(sqlQuery);

            Assert.IsNotNull(product);

            using (storage.Connection)
            {
                Assert.IsTrue(storage.Connection.State == System.Data.ConnectionState.Closed);
            }
        }

        [TestMethod]
        public void ConnectionStateDataReader_Test()
        {
            var sqlQuery = " SELECT ProductId AS Id, Name, Model, IsDeleted, CreatorUserId, CreationTime ";
            sqlQuery += "   ,LastModifierUserId, LastModificationTime, DeleterUserId, DeletionTime ";
            sqlQuery += "   FROM dbo.Product ";

            var storage = StorageFactory.AppTest;

            var dr = storage.ExecuteReader(sqlQuery);
            dr.Dispose();

            using (storage.Connection)
            {
                Assert.IsTrue(storage.Connection.State == System.Data.ConnectionState.Closed);
            }
        }
    }
}
