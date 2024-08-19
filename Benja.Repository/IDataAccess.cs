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
        public int Add();
        public int Edit();
        public int Delete();
        public T GetItem<T>(int id);
        public IEnumerable<T> GetList<T>(int id);
    }
}
