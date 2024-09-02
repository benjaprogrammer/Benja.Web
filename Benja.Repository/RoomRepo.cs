using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Benja.Library;
using Benja.Model;
namespace Benja.Repository
{
    public class RoomRepo :  BaseRepo
    {
        public RoomRepo(SqlServer sqlServer) 
        {
            _sqlServer = sqlServer;
        }
        public Task<int> Add(string sql, object? parameter)
        {
            return _sqlServer.ExecuteNonQuery(sql, parameter);
        }
        public Task<int> Edit(string sql, object? parameter)
        {
            return _sqlServer.ExecuteNonQuery(sql, parameter);
        }
        public Task<int> Delete(string sql, object? parameter)
        {
            return _sqlServer.ExecuteNonQuery(sql, parameter);
        }
        public Task<IEnumerable<RoomModel>> GetItem<RoomModel>(string sql, object parameter)
        {

            return _sqlServer.ExecuteQuery<RoomModel>(sql, parameter);
        }
        public Task<IEnumerable<RoomModel>> GetList<RoomModel>(string sql, object parameter)
        {
            return _sqlServer.ExecuteQuery<RoomModel>(sql, parameter);
        }
  
    }
}
