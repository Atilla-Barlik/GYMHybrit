using Entities.DailyNutritionDetails;
using Entities.DailyNutritionDetailsDto;
using Entities.DailyNutritionEntities;
using Entities.NutrientEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Services.DailyNutritionDetailsService
{

    public class DailyNutritionDetailsService : IDailyNutritionDetailsService
    {
        private string _baseURL = "https://localhost:7149";
        private List<DailyNutritionDetailsResponseModel>? returnResponse;
        private List<NutritionSummaryDto>? _summary;
        private List<TotalUsageNutritionDto>? _total;
        public async Task<bool> AddDailyNutrition(AddUpdateDailyNutritionDetailsRequest nutrientRequest)
        {
            var returnResponse = false;
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/DailyNutritionDetails";

                    var serializeContent = JsonConvert.SerializeObject(nutrientRequest);

                    var apiResponse = await client.PostAsync(url, new StringContent(serializeContent, Encoding.UTF8, "application/json"));

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.Created)
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

        public async Task<bool> DeleteDailyNutrition(DailyNutritionDetailsResponseModel nutrientRequest)
        {
            var returnResponse = false;
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/DailyNutritionDetails?id={nutrientRequest.DailyNutritionDetailsId}";

                    var serializeContent = JsonConvert.SerializeObject(nutrientRequest);
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

        public async Task<List<DailyNutritionDetailsResponseModel>> GetAllDailyNutritiontList()
        {
            returnResponse = new List<DailyNutritionDetailsResponseModel>();
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/DailyNutritionDetails";
                    var apiResponse = await client.GetAsync(url);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        var response = await apiResponse.Content.ReadAsStringAsync();

                        returnResponse = JsonConvert.DeserializeObject
                            <List<DailyNutritionDetailsResponseModel>>(response);

                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return returnResponse;
        }

        public Task<DailyNutritionDetailsResponseModel> GetDailyNutritionById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<NutritionSummaryDto>> GetTotalMeal(int DailyNutritionId)
        {
            _summary = new List<NutritionSummaryDto>();
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/DailyMealSummary/summary/{DailyNutritionId}";
                    var apiResponse = await client.GetAsync(url);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        var response = await apiResponse.Content.ReadAsStringAsync();

                        _summary = JsonConvert.DeserializeObject<List<NutritionSummaryDto>>(response);

                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return _summary;
        }

        public async Task<List<TotalUsageNutritionDto>> GetTotalUsageNutrition()
        {
            _total = new List<TotalUsageNutritionDto>();
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/TotalUsageNutrition/top10";
                    var apiResponse = await client.GetAsync(url);

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.OK)
                    {

                        var response = await apiResponse.Content.ReadAsStringAsync();

                        _total = JsonConvert.DeserializeObject
                            <List<TotalUsageNutritionDto>>(response);

                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            return _total;
        }

        public async Task<bool> UpdateDailyNutrition(DailyNutritionDetailsResponseModel nutrientRequest, int id)
        {
            var returnResponse = false;
            try
            {
                using (var client = new HttpClient())
                {
                    string url = $"{_baseURL}/api/DailyNutritionDetails";


                    var serializeContent = JsonConvert.SerializeObject(nutrientRequest);

                    var apiResponse = await client.PutAsync(url, new StringContent(serializeContent, Encoding.UTF8, "application/json"));

                    if (apiResponse.StatusCode == System.Net.HttpStatusCode.NoContent)
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
