using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Benja.Library;
using Benja.Model;
using Newtonsoft.Json.Linq;

namespace Benja.Repository
{
    public class MenuRepo : BaseRepo, IDataAccess
    {
        public MenuRepo(SqlServer sqlServer)
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
        public IEnumerable<MenuModel> GetItem<MenuModel>(string sql, object parameter)
        {
            return _sqlServer.ExecuteQuery<MenuModel>(sql, parameter);
        }
        public IEnumerable<RoomModel> GetList<RoomModel>(string sql, object parameter)
        {
            return _sqlServer.ExecuteQuery<RoomModel>(sql, parameter);
        }
      
    }
}
