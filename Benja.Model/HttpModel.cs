using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benja.Model
{
    public class HttpModel
    {
        public IHttpClientFactory httpClientFactory { get; set; }
        public HttpRequestMessage httpRequestMessage { get; set; }
        public HttpClient httpClient { get; set; }
    }
}
