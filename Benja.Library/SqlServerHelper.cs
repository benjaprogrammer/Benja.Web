
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using Microsoft.Extensions.Configuration;
namespace Benja.Library
{
    public class SqlServerHelper
    {
        #region Attribute

        private SqlConnection _SqlCon;
        private string _ConnectionString;
        private string _StrSql;

        #endregion
        #region Constructor

        public SqlServerHelper()
        {
            SqlCon = null;
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            ConnectionString = config.GetValue<string>("ConnectionStrings:ApartmentConnectionString");
            StrSql = string.Empty;
        }
        public SqlServerHelper(string connectionString)
        {
            SqlCon = null;
            ConnectionString = connectionString;
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
        public IEnumerable<T> ExecuteQuery<T>(string sql,object obj=null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query<T>(sql, obj).ToList();
            }
        }
        public List<dynamic> ExecuteQuery(string sql, object obj = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Query(sql, obj).ToList();
            }
        }
        public int ExecuteNonQuery(string sql, object obj = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.Execute(sql, obj);
            }
        }
        public object ExecuteScalar(string sql, object obj = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                return connection.ExecuteScalar(sql, obj);
            }
        }
        #endregion
    }
}
