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
    public class MenuRepo : BaseRepo
    {
        public MenuRepo(SqlServer sqlServer)
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
        public Task<IEnumerable<MenuModel>> GetItem<MenuModel>(string sql, object parameter)
        {
            return _sqlServer.ExecuteQuery<MenuModel>(sql, parameter);
        }
        public Task<IEnumerable<RoomModel>> GetList<RoomModel>(string sql, object parameter)
        {
            return _sqlServer.ExecuteQuery<RoomModel>(sql, parameter);
        }
      
    }
}
