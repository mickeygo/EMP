using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DotPlatform.Extensions;

namespace DotPlatform.Storage
{
    /// <summary>
    /// 关系型数据库存储
    /// </summary>
    public abstract class RdbmsStorageBase : IRdbmsStorage
    {
        private IDbConnection _connection;
        private readonly IRdbmsStorageProvider _provider;

        /// <summary>
        /// 初始化一个新的<see cref="RdbmsStorageBase"/>实例
        /// </summary>
        /// <param name="connectionName">连接名</param>
        /// <param name="provider">数据存储提供者</param>
        protected RdbmsStorageBase(string connectionName, IRdbmsStorageProvider provider)
        {
            this.ConnectionName = connectionName;
            this._provider = provider;
        }

        #region Properties

        public IDbConnection Connection
        {
            get
            {
                return _connection ?? (_connection = CreateConnection());
            }
        }

        public string ConnectionName { get; private set; }

        #endregion

        #region Query

        public abstract IEnumerable<T> Select<T>(string sqlQuery, object param = null, CommandType commandType = CommandType.Text);

        public abstract Task<IEnumerable<T>> SelectAsync<T>(string sqlQuery, object param = null, CommandType commandType = CommandType.Text);

        public abstract T FirstOrDefault<T>(string sqlQuery, object param = null, CommandType commandType = CommandType.Text);

        public abstract Task<T> FirstOrDefaultAsync<T>(string sqlQuery, object param = null, CommandType commandType = CommandType.Text);
     
        public abstract T Single<T>(string sqlQuery, object param = null, CommandType commandType = CommandType.Text);

        public abstract Task<T> SingleAsync<T>(string sqlQuery, object param = null, CommandType commandType = CommandType.Text);

        #endregion

        #region Execute

        public abstract void Execute(string sqlCommand, object param = null, CommandType commandType = CommandType.Text);

        public abstract Task ExecuteAsync(string sqlCommand, object param = null, CommandType commandType = CommandType.Text);

        public abstract IDataReader ExecuteReader(string sqlCommand, object param = null, CommandType commandType = CommandType.Text);

        public abstract Task<IDataReader> ExecuteReaderAsync(string sqlCommand, object param = null, CommandType commandType = CommandType.Text);

        public abstract T ExecuteScalar<T>(string sqlCommand, object param = null, CommandType commandType = CommandType.Text);

        public abstract Task<T> ExecuteScalarAsync<T>(string sqlCommand, object param = null, CommandType commandType = CommandType.Text);

        #endregion

        #region Pirvate Methods

        private IDbConnection CreateConnection()
        {
            if (ConnectionName.IsNullOrEmpty())
            {
                throw new DotPlatformException("The connection name is null or empty.");
            }

            return this._provider.CreateConnection(ConnectionName);
        }

        #endregion
    }
}
