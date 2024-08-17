using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benja.Model
{
    public  class ErrorResponseModel
    {
        public IEnumerable<string> ErrorMessage { get; set; }
        public ErrorResponseModel(string errorMessage):this(new List<string>() { errorMessage }) { }
        public ErrorResponseModel(IEnumerable<string> errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
