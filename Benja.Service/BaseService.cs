using Benja.Library;
using Benja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benja.Service
{
    public class BaseService
    {
        public SqlServer _sqlServer;
        public IHttpClientFactory _httpClientFactory;
        public HttpRequestMessage _httpRequestMessage;
        public HttpClient _httpClient;
        public string _baseUrl = "https://localhost:7098";
        public HttpModel _httpModel;
        public BaseService()
        {
          
        }
    }
}
