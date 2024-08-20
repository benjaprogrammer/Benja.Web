
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
            ConnectionString = config.GetValue<string>("ConnectionStrings:ApartmentConnectionString");
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
        public IEnumerable<T> ExecuteQuery<T>(string sql, object obj = null) 
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<T>(sql, obj);
            }
        }
        public IEnumerable<T> ExecuteQuery<T>(SqlTransaction trans, SqlConnection con, string sql, object obj = null)
        {
            return con.Query<T>(sql, obj, trans);
        }
        public IEnumerable<dynamic> ExecuteQuery(string sql, object obj = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query(sql, obj);
            }
        }
        public IEnumerable<dynamic> ExecuteQuery(string sql, SqlTransaction trans, SqlConnection con, object obj = null)
        {
            return con.Query(sql, obj, trans);
        }
        public int ExecuteNonQuery(string sql, object obj = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Execute(sql, obj);
            }
        }
        public int ExecuteNonQuery(string sql, SqlConnection con, SqlTransaction trans, object obj = null)
        {
            return con.Execute(sql, obj, trans);
        }
        public object ExecuteScalar(string sql, object obj = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.ExecuteScalar(sql, obj);
            }
        }
        public object ExecuteScalar(string sql, SqlConnection con, SqlTransaction trans, object obj = null)
        {
            return con.ExecuteScalar(sql, obj, trans);
        }
        #endregion
    }
}
