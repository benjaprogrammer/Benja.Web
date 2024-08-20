using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benja.Model
{
    public class PagingModel
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        private int _offSet = 0;
        public int Offset
        {
            set
            {
                _offSet = value;
            }
            get
            {
                if (CurrentPage == 1)
                {
                    return 0;
                }
                else
                {
                    if (_offSet == 0)
                    {
                        return 0;
                    }
                    return _offSet = (CurrentPage * PageSize) - PageSize;
                }
            }
        }
        public int Next
        {
            get
            {
                return PageSize;
            }
        }
    }
}
