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
        public Task<int> Add(string sql, object? parameter);
        public Task<int> Edit(string sql, object? parameter);
        public Task<int> Delete(string sql, object? parameter);
        public Task<IEnumerable<T>> GetItem<T>(string sql, object parameter);
        public Task<IEnumerable<T>> GetList<T>(string sql, object parameter);
    }
}
