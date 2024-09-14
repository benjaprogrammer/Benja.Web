using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benja.Model
{
    public  class UserModel:BaseModel
    {
        public string password { get; set; }        
        public string email { get; set; }
        public string passwordHash { get; set; }
    }
}
