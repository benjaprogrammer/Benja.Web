﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Benja.Model;
namespace Benja.ViewModel
{
    public class RoomListVM: BaseVM
    {
        public RoomModel roomModel { get; set; }
        public PagingModel pagingModel { get; set; }
    }
}
