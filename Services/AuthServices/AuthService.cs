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
        private readonly HttpClient _http;

        public AuthService(HttpClient http)
        {
            _http = http;
        }
        public async Task<int> LoginAsync(LoginRequest request)
        {
            var response = await _http.PostAsJsonAsync("api/Auth/login", request);
            if (!response.IsSuccessStatusCode)
                return 0;

            var payload = await response.Content.ReadFromJsonAsync<LoginResponse>();
            return payload?.UserId ?? 0;
        }
    }
}
