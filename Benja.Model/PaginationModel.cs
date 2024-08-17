using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benja.Model
{
    public class PaginationModel
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;

        public bool HasNextPage => CurrentPage < TotalPages;

        public void Calculate(int currentPage, int totalRecords)
        {
            CurrentPage = currentPage;
            PageSize =10;
            TotalPages = (int)Math.Ceiling(totalRecords / (double)PageSize);
        }
    }
}