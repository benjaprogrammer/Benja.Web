using Benja.Library;
using Benja.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Benja.Service
{
    public class MenuService : BaseService
    {
        public MenuService(IHttpClientFactory iHttpClientFactory)
        {
            _httpModel = Http.CreateHttp(new HttpModel()
            {
                httpClient = _httpClient,
                httpClientFactory = iHttpClientFactory
            });
        }
        public async void GetItem()//Task<ApiResponse<MenuModel>>
        {
            _httpModel.httpRequestMessage.Method = HttpMethod.Get;
            _httpModel.httpRequestMessage.RequestUri = new Uri(_baseUrl + "/api/v1/menu/getitem?menuModel=string");
            var httpResponseMessage = await _httpModel.httpClient.SendAsync(_httpModel.httpRequestMessage);
            IEnumerable<MenuModel> listMenuModel;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
                ApiResponse<MenuModel> ApiResponse = JsonConvert.DeserializeObject<ApiResponse<MenuModel>>(jsonString);
            }
            else
            {
                //return new ApiResponse<MenuModel>();
            }
        }
    }
}
