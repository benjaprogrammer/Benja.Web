using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benja.Model
{
    public  class UserModel
    {
        public Guid Id { get; set; } 
        public string UserName { get; set; }
        public string Password { get; set; }        
        public string FistName { get; set; }
        public string LastName { get; set; }    
        public string Email { get; set; }

    }
}
