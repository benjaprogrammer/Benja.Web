using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Benja.Model;
using System.Net.Http.Headers;
using System.Net;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Http.Json;
using System.Text.Json.Serialization.Metadata;
namespace Benja.Library
{
    public  class HTTP
    {
        public  HttpModel CreateHttp(HttpModel httpModel)
        {
            httpModel.httpClient= httpModel.httpClientFactory.CreateClient();
            httpModel.httpRequestMessage = new HttpRequestMessage();
            httpModel.httpRequestMessage.Headers.Add("Accept", "application/json");
            httpModel.httpRequestMessage.Headers.Add("Authorization", "Bearer ");
            return httpModel;
        }
        public StringContent SerializeObject(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8,"application/json");
        }
    }
}
