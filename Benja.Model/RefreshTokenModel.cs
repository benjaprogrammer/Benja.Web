using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Benja.Model
{
    public  class RefreshTokenModel
    {
        public Guid Id { get; set; }    
        public string Token { get; set; }   
        public Guid UserId { get; set; }
    }
}
