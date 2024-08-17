using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benja.Model
{
    public class TblSite
    {
        public Guid f_site_id { get; set; }
        public string f_site_name { get; set; }
        public string f_desc { get; set; }
        public string f_site_letter { get; set; }
        public int f_site_no { get; set; }
        public DateTime f_crt_dt { get; set; }
    }
}
