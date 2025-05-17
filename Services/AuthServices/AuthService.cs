using Entities.AppUserEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private string _baseURL = "https://localhost:7149";
        
        //public async Task<int> LoginAsync(LoginRequest request)
        //{
        //    var response = await _http.PostAsJsonAsync("api/Auth/login", request);
        //    if (!response.IsSuccessStatusCode)
        //        return 0;

        //    var payload = await response.Content.ReadFromJsonAsync<LoginResponse>();
        //    return payload?.UserId ?? 0;
        //}

        public async Task<int> LoginAsync(LoginRequest request)
        {
            var returnResponse = false;
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/Auth/login";

                    var serializeContent = JsonConvert.SerializeObject(request);

                    var apiResponse = await client.PostAsync(url, new StringContent(serializeContent, Encoding.UTF8, "application/json"));
                    var response = await apiResponse.Content.ReadFromJsonAsync<LoginResponse>();

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        return response.UserId;

                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return 0;
        }
    }
}
