using Entities.AvgKcalDailyEntities;
using Entities.UserExerciseProgramEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Services.AvgKcalDailyServices
{
    public class AvgKcalDailyService : IAvgKcalDailyService
    {
        private string _baseURL = "https://localhost:7149";
        private List<AvgKcalDailyResponseModel> _avgKcalDailyResponseModels;
        public async Task<bool> AddAvgKcalDaily(AddUpdateAvgKcalDailyRequest request)
        {
            var returnResponse = false;
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/AvgKcalDaily";

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

        public async Task<List<AvgKcalDailyResponseModel>> GetAppUserExerciseProgramDetails(int AppUserId)
        {
            _avgKcalDailyResponseModels = new List<AvgKcalDailyResponseModel>();
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/AvgKcalDaily/avgKcalDaily/{AppUserId}";
                    var apiResponse = await client.GetAsync(url);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var response = await apiResponse.Content.ReadAsStringAsync();

                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true // JSON'daki anahtar isimleri için büyük/küçük harf duyarlılığını kapat
                        };

                        _avgKcalDailyResponseModels = System.Text.Json.JsonSerializer.Deserialize<List<AvgKcalDailyResponseModel>>(response, options);
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata mesajını loglama
                Console.WriteLine($"Hata: {ex.Message}");
            }

            return _avgKcalDailyResponseModels;
        }
    }
}
