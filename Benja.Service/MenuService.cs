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
using static System.Net.WebRequestMethods;

namespace Benja.Service
{
    public class MenuService : BaseService
    {
        public MenuService(IHttpClientFactory iHttpClientFactory, HTTP http)
        {
            _http = http;
            _httpModel = _http.CreateHttp(new HttpModel()
            {
                httpClient = _httpClient,
                httpClientFactory = iHttpClientFactory
            });
        }
        public async Task<ApiResponse<MenuModel>> GetItem()
        {
            _httpModel.httpRequestMessage.Method = HttpMethod.Get;
            _httpModel.httpRequestMessage.RequestUri = new Uri(_baseUrl + "/api/v1/menu/getitem?menuModel=string");
            var httpResponseMessage = await _httpModel.httpClient.SendAsync(_httpModel.httpRequestMessage);
            IEnumerable<MenuModel> listMenuModel;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResponse<MenuModel>>(jsonString);
            }
            else
            {
                return new ApiResponse<MenuModel>();
            }
        }
        public async Task<ApiResponse<int>> Add(MenuModel menuModel)
        {
            _httpModel.httpRequestMessage.Content = _http.SerializeObject(menuModel);
            _httpModel.httpRequestMessage.Method = HttpMethod.Post;
            _httpModel.httpRequestMessage.RequestUri = new Uri(_baseUrl + "/api/v1/menu/add");
            var httpResponseMessage = await _httpModel.httpClient.SendAsync(_httpModel.httpRequestMessage);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResponse<int>>(jsonString);
            }
            else
            {
                return new ApiResponse<int>();
            }
        }
    }
}
