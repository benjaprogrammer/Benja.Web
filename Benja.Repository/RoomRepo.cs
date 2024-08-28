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
    public class RoomRepo :  BaseRepo,IDataAccess
    {
        public RoomRepo(SqlServer sqlServer) 
        {
            _sqlServer = sqlServer;

        }
        public int Add(string sql, object? parameter)
        {
            return _sqlServer.ExecuteNonQuery(sql, parameter);
        }
        public int Edit(string sql, object? parameter)
        {
            return _sqlServer.ExecuteNonQuery(sql, parameter);
        }
        public int Delete(string sql, object? parameter)
        {
            return _sqlServer.ExecuteNonQuery(sql, parameter);
        }
        public IEnumerable<RoomModel> GetItem<RoomModel>(string sql, object parameter)
        {

            return _sqlServer.ExecuteQuery<RoomModel>(sql, parameter);
        }
        public IEnumerable<RoomModel> GetList<RoomModel>(string sql, object parameter)
        {
            return _sqlServer.ExecuteQuery<RoomModel>(sql, parameter);
        }
  
    }
}
