using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace KC.Template.BackgroundService.Domain
{
    /// <summary>
    /// 注册的时候 InstancePerLifetimeScope
    /// 线程内唯一（也就是单个请求内唯一）
    /// </summary>
    public class ThisDBContext
    {
        private IDbConnection _dbConnection;
        private readonly string _sqlConnectionString;
        public ThisDBContext(IConfiguration Configuration)
        {
            _sqlConnectionString = Configuration.GetConnectionString("ThisDBConnection");
        }
        
        public IDbConnection DbConnection
        {
            get
            {
                if (_dbConnection == null)
                {
                    _dbConnection = new SqlConnection(_sqlConnectionString);
                }
                return _dbConnection;
            }
        }

        public IDbTransaction DbTransaction { get; set; }

        /// <summary>
        /// 是否已被提交
        /// </summary>
        public bool Committed { get; private set; } = true;

        /// <summary>
        /// 开启事务
        /// </summary>
        public void BeginTransaction()
        {
            Committed = false;
            bool isClosed = DbConnection.State == ConnectionState.Closed;
            if (isClosed) DbConnection.Open();
            DbTransaction = DbConnection?.BeginTransaction();
        }

        /// <summary>
        /// 事务提交
        /// </summary>
        public void CommitTransaction()
        {
            DbTransaction?.Commit();
            Committed = true;

            Dispose();
        }

        /// <summary>
        /// 事务回滚
        /// </summary>
        public void RollBackTransaction()
        {
            DbTransaction?.Rollback();
            Committed = true;

            Dispose();
        }

        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            DbTransaction?.Dispose();
            if (DbConnection.State == ConnectionState.Open)
                _dbConnection?.Close();
        }
    }
}
