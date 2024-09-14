using Benja.Model;
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
        public int id { get; set; } = 0;
        public DateTime createDate { get; set; } = DateTime.Now;
        public string createBy { get; set; } 
        public DateTime updateDate { get; set; } = DateTime.Now;
        public string updateBy { get; set; } 
        public Guid migrationGuID { get; set; }
    }
}
