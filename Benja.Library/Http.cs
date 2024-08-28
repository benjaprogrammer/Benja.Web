using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Benja.Model;
using System.Net.Http.Headers;
using System.Net;
namespace Benja.Library
{
    public static class Http
    {
        public static HttpModel CreateHttp(HttpModel httpModel)
        {
            httpModel.httpClient= httpModel.httpClientFactory.CreateClient();
            httpModel.httpRequestMessage = new HttpRequestMessage();

            httpModel.httpRequestMessage.Headers.Add("Accept", "application/json");
            //httpModel.httpRequestMessage.Headers.Add("Content-Type", "");
            httpModel.httpRequestMessage.Headers.Add("Authorization", "Bearer ");
            return httpModel;
        }
    }
}
