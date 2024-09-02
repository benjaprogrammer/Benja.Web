using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Benja.Model
{
    public class BaseModel
    {
        public int id { get; set; } 
        public DateTime createDate { get; set; } 
        public string createBy { get; set; } 
        public DateTime updateDate { get; set; } 
        public string updateBy { get; set; } 
        public Guid migrationGuID { get; set; }
    }
}
