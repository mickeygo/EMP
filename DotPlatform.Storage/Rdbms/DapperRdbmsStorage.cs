using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace DotPlatform.Storage.Rdbms
{
    /// <summary>
    /// 基于 Dapper 的关系型数据库存储。
    /// 使用基于 Dapper 的框架，在执行 Query/Execute 操作后会自动关闭与 Db 的连接，包括 ExecuteReader，关闭 DataReader 时同时也会关闭连接。
    /// 参数：1) [... WHERE CategoryID = @catgs;  new { catgs = 1 }]  => 匿名类型
    ///     2) [... WHERE CategoryID IN @catgs;  new { catgs = new int[] { 1, 4 } }] =>自動轉成 WHERE col in (@arg1,@arg2)
    ///     3) Book book = new Book(); [INSERT / UPDATE / DELETE ... VALUES(@name); conn.Execute(query, book)] ==> 等价于 conn.Execute(query, new {name = "C#"});
    /// 
    /// </summary>
    public class DapperRdbmsStorage : RdbmsStorageBase
    {
        public DapperRdbmsStorage(IRdbmsStorageProvider provider) : base(provider)
        {
        }

        #region Query

        public override IEnumerable<T> Select<T>(string sqlQuery, object param = null)
        {
            return this.Connection.Query<T>(sqlQuery, param);
        }

        public override async Task<IEnumerable<T>> SelectAsync<T>(string sqlQuery, object param = null)
        {
            return await this.Connection.QueryAsync<T>(sqlQuery, param);
        }

        public override T FirstOrDefault<T>(string sqlQuery, object param = null)
        {
            return this.Connection.QueryFirstOrDefault<T>(sqlQuery, param);
        }

        public override async Task<T> FirstOrDefaultAsync<T>(string sqlQuery, object param = null)
        {
            return await this.Connection.QueryFirstOrDefaultAsync<T>(sqlQuery, param);
        }

        public override T Single<T>(string sqlQuery, object param = null)
        {
            return this.Connection.QuerySingle<T>(sqlQuery, param);
        }

        public override async Task<T> SingleAsync<T>(string sqlQuery, object param = null)
        {
            return await this.Connection.QuerySingleAsync<T>(sqlQuery, param);
        }

        #endregion

        #region Execute

        public override void Execute(string sqlCommand, object param = null, CommandType commandType = CommandType.Text)
        {
            var transaction = this.Connection.BeginTransaction();

            try
            {
                var commandDef = BuildCommandDefinition(sqlCommand, param, commandType, transaction);
                this.Connection.Execute(commandDef);

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public override async Task ExecuteAsync(string sqlCommand, object param = null, CommandType commandType = CommandType.Text)
        {
            var transaction = this.Connection.BeginTransaction();

            try
            {
                var commandDef = BuildCommandDefinition(sqlCommand, param, commandType, transaction);
                var result = this.Connection.ExecuteAsync(commandDef);

                transaction.Commit();

                await result;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        public override IDataReader ExecuteReader(string sqlCommand, object param = null, CommandType commandType = CommandType.Text)
        {
            var commandDef = BuildCommandDefinition(sqlCommand, param, commandType);
            return this.Connection.ExecuteReader(commandDef);
        }

        public override async Task<IDataReader> ExecuteReaderAsync(string sqlCommand, object param = null, CommandType commandType = CommandType.Text)
        {
            var commandDef = BuildCommandDefinition(sqlCommand, param, commandType);
            return await this.Connection.ExecuteReaderAsync(commandDef);
        }

        public override T ExecuteScalar<T>(string sqlCommand, object param = null, CommandType commandType = CommandType.Text)
        {
            var commandDef = BuildCommandDefinition(sqlCommand, param, commandType);
            return this.Connection.ExecuteScalar<T>(commandDef);
        }

        public override async Task<T> ExecuteScalarAsync<T>(string sqlCommand, object param = null, CommandType commandType = CommandType.Text)
        {
            var commandDef = BuildCommandDefinition(sqlCommand, param, commandType);
            return await this.Connection.ExecuteScalarAsync<T>(commandDef);
        }

        #endregion

        #region Private Methods

        private CommandDefinition BuildCommandDefinition(string sql, object param, CommandType commandType, IDbTransaction transaction = null)
        {
            return new CommandDefinition(commandText: sql, parameters: param, commandType: commandType, transaction: transaction);
        }

        #endregion
    }
}
