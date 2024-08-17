using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benja.Library
{
    public class BcryptPasswordHasher
    {
        public string HashPassword(string password)
        { 
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
