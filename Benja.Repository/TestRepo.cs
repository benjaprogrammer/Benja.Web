using Benja.Library;
using Benja.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benja.Repository
{
    public class TestRepo : BaseRepo
    {

        public TestRepo(SqlServer sqlServer) 
        {
            _sqlServer = sqlServer;

        }
        public Task<IEnumerable<RoomModel>> ExecuteQuery(string sql, object parameter)
        {

            return _sqlServer.ExecuteQuery<RoomModel>(sql, parameter);
        }
        public Task<int> ExecuteNonQuery(string sql, object? parameter)
        {

            return _sqlServer.ExecuteNonQuery(sql, parameter);
        }
        public Task<object> ExecuteScalar(string sql)
        {
            return _sqlServer.ExecuteScalar(sql, null);
        }
        public Task<int> ExecuteTransaction(string sql, object? parameter, SqlConnection con, SqlTransaction trans)
        {
            return _sqlServer.ExecuteNonQuery(sql, con, trans, parameter);
        }
    }
}
