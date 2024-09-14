using Benja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benja.Model
{
    public  class RegisterModel:BaseModel
    {
        public string email { get; set; }
        public string userName { get; set; }
        public string password { get; set; }    
        public string confirmPassword { get; set; }
    }
}
