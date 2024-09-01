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
        public int? id { get; set; } = null;
        public DateTime? createDate { get; set; } = null;
        public string? createBy { get; set; } = null;
        public DateTime? updateDate { get; set; } = null;
        public string? updateBy { get; set; } = null;

    }
}
