using Benja.Library;
using Benja.Model;
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
        public Task<int> Add(dynamic dynamic);
        //public Task<int> Edit(IModel imodel);
        //public Task<int> Delete(IModel imodel);
        //public Task<IEnumerable<T>> GetItem<T>(IModel imodel);
        //public Task<IEnumerable<T>> GetList<T>(IModel imodel);
    }
}
