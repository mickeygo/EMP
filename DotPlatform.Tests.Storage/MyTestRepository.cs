using DotPlatform.Storage.Rdbms;
using DotPlatform.Storage;

namespace DotPlatform.Tests.Storage
{
    internal class MyTestRepository : DapperRdbmsStorage
    {
        public MyTestRepository(IRdbmsStorageProvider provider) : base("MyTest", provider)
        {
        }
    }
}
