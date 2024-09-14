using Benja.Library;
using Benja.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benja.Service
{
    public class AuthenService : BaseService
    {
        public AuthenService(IHttpClientFactory iHttpClientFactory, HTTP http)
        {
            _http = http;
            _httpModel = _http.CreateHttp(new HttpModel()
            {
                httpClientFactory = iHttpClientFactory
            });
        }
        //public async Task<ApiResponse<MenuModel>> GetItem()
        //{
        //	_httpModel.httpRequestMessage.Method = HttpMethod.Get;
        //	_httpModel.httpRequestMessage.RequestUri = new Uri(_baseUrl + "/api/v1/menu/getitem?menuModel=string");
        //	var httpResponseMessage = await _httpModel.httpClient.SendAsync(_httpModel.httpRequestMessage);
        //	IEnumerable<MenuModel> listMenuModel;
        //	if (httpResponseMessage.IsSuccessStatusCode)
        //	{
        //		var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
        //		return JsonConvert.DeserializeObject<ApiResponse<MenuModel>>(jsonString);
        //	}
        //	else
        //	{
        //		return new ApiResponse<MenuModel>();
        //	}
        //}
        public async Task<ApiResponse<string>> Register(RegisterModel registerModel)
        {
            _httpModel.httpRequestMessage.Content = _http.SerializeObject(registerModel);
            _httpModel.httpRequestMessage.Method = HttpMethod.Post;
            _httpModel.httpRequestMessage.RequestUri = new Uri(_baseUrl + "/api/v1/authen/register");
            var httpResponseMessage = await _httpModel.httpClient.SendAsync(_httpModel.httpRequestMessage);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResponse<string>>(jsonString);
            }
            else
            {
                return new ApiResponse<string>();
            }
        }
        public async Task<ApiResponse<AuthenticateUserModel>> Login(LoginRequestModel loginRequestModel)
        {
            _httpModel.httpRequestMessage.Content = _http.SerializeObject(loginRequestModel);
            _httpModel.httpRequestMessage.Method = HttpMethod.Post;
            _httpModel.httpRequestMessage.RequestUri = new Uri(_baseUrl + "/api/v1/authen/login");
            var httpResponseMessage = await _httpModel.httpClient.SendAsync(_httpModel.httpRequestMessage);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var jsonString = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiResponse<AuthenticateUserModel>>(jsonString);
            }
            else
            {
                return new ApiResponse<AuthenticateUserModel>();
            }
        }
    }
}
