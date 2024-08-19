using Benja.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benja.Repository
{
    public class BaseRepo
    {
        public  SqlServer _sqlServer;
        public BaseRepo(SqlServer sqlServer)
        {
            _sqlServer = sqlServer;
        }
    }
}
