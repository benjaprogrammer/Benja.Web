﻿using Benja.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benja.Library;
namespace Benja.Repository
{
    public class SiteRepo
    {
        public IEnumerable<SiteModel> GetAll()
        {
            SqlServer sql = new SqlServer();
            return sql.ExecuteQuery<SiteModel>("select * from tbl_site", null);
        }
    }
}
