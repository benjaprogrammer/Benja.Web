using Benja.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Benja.Repository
{
    public interface IDataAccess
    {
        public int Add(string sql, object? parameter);
        public int Edit(string sql, object? parameter);
        public int Delete(string sql, object? parameter);
        public IEnumerable<T> GetItem<T>(string sql, object parameter);
        public IEnumerable<T> GetList<T>(string sql, object parameter);
    }
}
