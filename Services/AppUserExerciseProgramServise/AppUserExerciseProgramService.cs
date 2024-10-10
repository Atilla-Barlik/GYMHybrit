using Entities.AppUserExerciseProgramEntities;
using Entities.DailyNutritionDetails;
using Entities.UserExerciseProgramEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services.AppUserExerciseProgramServise
{
    public class AppUserExerciseProgramService : IAppUserExerciseProgramService
    {
        private string _baseURL = "https://localhost:7149";
        private readonly HttpClient _httpClient;
        private List<CombinedExerciseDataResponseModel> _combinedData;

        //private AddUpdateAppUserExerciseProgramRequest _addRequest;
        public async Task<bool> AddAppUserExercise(AppUserExerciseProgramResponseModel request)
        {
            var returnResponse = false;
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/AppUserExerciseProgram";

                    var serializeContent = JsonConvert.SerializeObject(request);

                    var apiResponse = await client.PostAsync(url, new StringContent(serializeContent, Encoding.UTF8, "application/json"));

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        return true;

                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return returnResponse;
        }

        public async Task<List<CombinedExerciseDataResponseModel>> GetAppUserExerciseProgramDetails(int AppUserId)
        {
            _combinedData = new List<CombinedExerciseDataResponseModel>();
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/AppUserExerciseProgram/user-exercises/{AppUserId}";
                    var apiResponse = await client.GetAsync(url);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var response = await apiResponse.Content.ReadAsStringAsync();

                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true // JSON'daki anahtar isimleri için büyük/küçük harf duyarlılığını kapat
                        };

                        _combinedData = System.Text.Json.JsonSerializer.Deserialize<List<CombinedExerciseDataResponseModel>>(response, options);
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata mesajını loglama
                Console.WriteLine($"Hata: {ex.Message}");
            }

            return _combinedData;
        }

        public async Task<bool> DeleteAppUserExerciseProgram(AddUpdateAppUserExerciseProgramRequest appUserExerciseProgramRequest)
        {
            var returnResponse = false;
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/AppUserExerciseProgram?id={appUserExerciseProgramRequest.AppUserExerciseProgramId}";

                    var serializeContent = JsonConvert.SerializeObject(appUserExerciseProgramRequest);
                    var request = new HttpRequestMessage();
                    request.Method = HttpMethod.Delete;
                    request.RequestUri = new Uri(url);
                    request.Content = new StringContent(serializeContent, Encoding.UTF8, "application/json");

                    var apiResponse = await client.SendAsync(request);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        return true;

                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return returnResponse;
        }
    }
}
