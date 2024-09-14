
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using Microsoft.Extensions.Configuration;
namespace Benja.Library
{
    public class SqlServer
    {
        #region Attribute

        private SqlConnection _SqlCon;
        private string _ConnectionString;
        private string _StrSql;

        #endregion
        #region Constructor

        public SqlServer()
        {
            SqlCon = null;
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            ConnectionString = config.GetValue<string>("ConnectionStrings:CoffeeShopConnectionString");
            StrSql = string.Empty;
        }
        #endregion
        #region Property

        public string StrSql
        {
            set
            {
                _StrSql = value;
            }
            get
            {
                return _StrSql;
            }
        }
        public SqlConnection SqlCon
        {
            set
            {
                _SqlCon = value;
            }
            get
            {
                return _SqlCon;
            }
        }
        public string ConnectionString
        {
            set
            {
                _ConnectionString = value;
            }
            get
            {
                return _ConnectionString;
            }
        }

        #endregion
        #region Operation

        public void OpenSqlCon()
        {
            SqlCon = new SqlConnection(ConnectionString);

            SqlCon.Open();
        }
        public void CloseSqlCon()
        {
            SqlCon.Close();
        }
        public SqlConnection GetSqlCon()
        {
            return SqlCon;
        }
        public async Task<IEnumerable<T>> ExecuteQuery<T>(string sql, object obj = null) 
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return await connection.QueryAsync<T>(sql, obj);
            }
        }
        public async Task<IEnumerable<T>> ExecuteQuery<T>(SqlTransaction trans, SqlConnection con, string sql, object obj = null)
        {
            return await con.QueryAsync<T>(sql, obj, trans);
        }
        public async Task<IEnumerable<dynamic>> ExecuteQuery(string sql, object obj = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return await connection.QueryAsync(sql, obj);
            }
        }
        public async Task<IEnumerable<dynamic>> ExecuteQuery(string sql, SqlTransaction trans, SqlConnection con, object obj = null)
        {
            return await con.QueryAsync(sql, obj, trans);
        }
        public async Task<int> ExecuteNonQuery(string sql, object obj = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return await connection.ExecuteAsync(sql, obj);
            }
        }
        public async Task<int> ExecuteNonQuery(string sql, SqlConnection con, SqlTransaction trans, object obj = null)
        {
            return await con.ExecuteAsync(sql, obj, trans);
        }
        public async Task<object?> ExecuteScalar(string sql, object obj = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return await connection.ExecuteScalarAsync(sql, obj);
            }
        }
        public async Task<object?> ExecuteScalar(string sql, SqlConnection con, SqlTransaction trans, object obj = null)
        {
            return await con.ExecuteScalarAsync(sql, obj, trans);
        }
        #endregion
    }
}
